using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Configuration;


namespace LogUtility
{
    class FileAdapter : ILogger
    {
        public void Log(Exception ex)
        {
            
            try
            {
                string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
                string filepath = logFilePath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name

                if (!Directory.Exists(logFilePath))
                    Directory.CreateDirectory(logFilePath);
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }

                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + "---- Error Message:" + " " + ex.Message.ToString() + "---- Exception Type:" + " " + ex.GetType().ToString() +"---- StackTrace :" + " " + ex.StackTrace.ToString();
                    sw.WriteLine("----------------*Start*----------------");
                   sw.WriteLine(error);
                    sw.WriteLine("-------------*End*----------------");
                    sw.Flush();
                    sw.Close();

                }
            }
            catch (Exception ce)
            {
                throw new Exception(ce.Message);
            }

        }
    }

    public class DatabaseAdapter : ILogger
    {
        public void Log(Exception ex)
        {
            //Exception logging in Database
        }
    }

    public class EventLogAdapter : ILogger
    {
        public void Log(Exception ex)
        {
            //Exception logging in Event Viewer 
        }
    }
}
