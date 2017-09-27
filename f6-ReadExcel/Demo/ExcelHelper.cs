using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ReadExcel
{
    public class ExcelHelper
    {
        public static object GetExcelFile(string filePath, string extension)
        {
            object wk = null;
            try
            {                
                using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (extension == ".xlsx")
                    {
                        wk = new XSSFWorkbook(fs);
                    }
                    else
                    {
                        wk = new HSSFWorkbook(fs);
                    }                    
                    fs.Close();
                }
                return wk;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        public static ISheet GetExcelSheet(XSSFWorkbook wk, string sheetname)
        {
            try
            {
                ISheet sheet = wk.GetSheet(sheetname);              
                return sheet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ISheet GetExcelSheet(HSSFWorkbook wk, string sheetname)
        {
            try
            {
                ISheet sheet = wk.GetSheet(sheetname);
                return sheet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetCellValue(ISheet sheet,int column, int row)
        {
            try
            {
                ICell cell = sheet.GetRow(row).GetCell(column);
                return cell.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
