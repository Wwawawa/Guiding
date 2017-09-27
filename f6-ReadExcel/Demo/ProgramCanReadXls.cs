using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Threading;
using System.Diagnostics;
using NPOI.HSSF.UserModel;

namespace ReadExcel
{

    delegate string AsyncFoo(ISheet sheet);
    class Program
    {
        public static object syncRoot = new object();
        public static List<Test> array = new List<Tset>();
        public static List<string> messageList = new List<string>();
        public static TextWriterTraceListener myListener = Common.getWritelogInstance();
        static void Main(string[] args)
        {
            try
            {
                DirectoryInfo TheFolder = new DirectoryInfo(Constants.ExcelFolderPath);

                foreach (FileInfo file in TheFolder.GetFiles())
                {
                    ReadExcel(file.FullName);
                    File.Copy(file.FullName, Path.Combine(Constants.MoveExcelTo, file.Name), true);
                    File.Delete(file.FullName);
                }
            }
            catch(Exception ex)
            {
                myListener.WriteLine(ex.ToString());
            }
            finally
            {
                myListener.Flush();
                myListener = null;
            }
        }

        private static void ReadExcel(string fileName)
        {            
            try
            {
                Console.WriteLine("Start Read Excel " + fileName);
                myListener.WriteLine("Start Read Excel " + fileName);
                List<Task> tasks = new List<Task>();
                XSSFWorkbook wxlsx = null;
                HSSFWorkbook wxls = null;

                string extension = Path.GetExtension(fileName);
                if (extension == ".xlsx")
                {
                    wxlsx = (XSSFWorkbook)ExcelHelper.GetExcelFile(fileName, extension);
                }
                else
                {
                    wxls = (HSSFWorkbook)ExcelHelper.GetExcelFile(fileName, extension);
                }
                if (wxlsx != null || wxls!=null)
                {
                    for (int i = 1; i <= 30; i++)
                    {
                        ISheet sheet = null;
                        if (wxlsx != null) {
                            sheet = ExcelHelper.GetExcelSheet(wxlsx, "sheetName " + i.ToString());
                        }
                        else
                        {
                            sheet = ExcelHelper.GetExcelSheet(wxls, "sheetName " + i.ToString());
                        }

                        if (sheet != null)
                        {
                            tasks.Add(Task.Factory.StartNew(() => ReadSheet(sheet)));
                        }
                    }
                }
                Task.WaitAll(tasks.ToArray());

                if (messageList.Count > 0)
                {
                    foreach (string exce in messageList)
                    {
                        myListener.WriteLine(exce);
                    }
                }  

                Console.WriteLine("End Read Excel " + fileName);
                myListener.WriteLine("End Read Excel " + fileName);

            }
            catch (Exception ex)
            {
                myListener.WriteLine("Read excel " + fileName +" error: " + ex.ToString());
                throw ex; 
            }
        }
                
        private static void ReadSheet(ISheet sheet)
        {
            Test test = new Test();
            string message = "";
            //Column index: E=4;G=6;H=7;I=8;
            try
            {
                string cellValue_G3 = ExcelHelper.GetCellValue(sheet, 6, 2);
                message = "Read sheet " + sheet.SheetName + " successfully!";
            }
            catch (Exception ex)
            {
                message ="Read sheet "+ sheet.SheetName + " error: " + ex.ToString();
            }
            finally
            {
                lock (syncRoot)
                {
                    array.Add(test);
                    messageList.Add(message);
                }
            }            
        }
    }    
}
