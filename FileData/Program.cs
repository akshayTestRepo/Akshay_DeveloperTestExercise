using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using System.Configuration;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            FileOperations objFileOperation = new FileOperations(ConfigurationManager.AppSettings["LogProvider"]);
            objFileOperation.CaptureUserInput();

        }

       
    }
}
