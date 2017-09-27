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

namespace ReadExcel
{    
    class Program
    {
        public static List<string> array=new List<string>();
        
        static void Main(string[] args)
        {
            #region excel
            Console.WriteLine("start!");
            List<Task> tasks=new List<Task>();          
            XSSFWorkbook wk = ExcelHelper.GetExcelFile("C:/test.xlsm");
            if (wk != null)
            {
                for (int i = 1; i <= 30; i++)
                {
                    ISheet sheet = ExcelHelper.GetExcelSheet(wk, "name " + i.ToString());
                    if (sheet != null)
                    {
                        tasks.Add(Task.Factory.StartNew(()=>ReadExcel(sheet)));
                    }
                }
            }
            Task.WaitAll(tasks.ToArray());
            string a = string.Join(",", array);
            Console.WriteLine(a);
            #endregion
            Console.ReadLine();

        }

        private static void ReadExcel(ISheet sheet)
        {
            //Column index: E=4;G=6;H=7;I=8;
            
            string cellValue_G3 = ExcelHelper.GetCellValue(sheet, 6, 2);     

            //Console.WriteLine(cellValue_G3);
            //Console.Read();
            array.Add(sheet.SheetName + " " + Thread.CurrentThread.ManagedThreadId);
        }
    }    
}
