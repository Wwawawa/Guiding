
using System.Collections.Specialized;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace ReadExcel
{
    public static class Common
    {
        /// <summary>
        /// get value from app config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string value = appSettings.Get(key);
            return value;
        }

        private static TextWriterTraceListener myListener = new TextWriterTraceListener(Constants.LogFilePath);
        /// <summary>
        /// get instance
        /// </summary>
        /// <returns></returns>
        public static TextWriterTraceListener getWritelogInstance()
        {            
            if (!Directory.Exists(Constants.LogFolderPath))
            {
                Directory.CreateDirectory(Constants.LogFolderPath);
            }
            return myListener;
        }
    }
}
