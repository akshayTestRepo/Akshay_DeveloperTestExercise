using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using LogUtility;
namespace FileData
{
    public class FileOperations
    {
        Adapter adapter = null;
  
        public FileOperations(string type)
        {
            adapter = new Adapter(type);
        }
        /// <summary>
        /// Modified by: Akshay Pisal
        /// Last Modified: 2/1/2019
        /// Description: Method takes User Input and calls refactored method to perform conditional call to thirdparty tool
        /// </summary>                 
        public void CaptureUserInput()
        {
            try
            {
                Console.WriteLine("Please enter command to get file information.");
                string strInput = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine(FileOperator(strInput));
                Console.WriteLine();
                ContinueAnotherOperation();
            }
            catch (Exception ex)
            {
                adapter.Log(ex);
                Console.WriteLine("Application error has occured.Please try after sometime.");
                ContinueAnotherOperation();
            }
        }

        /// <summary>
        /// Modified by: Akshay Pisal
        /// Last Modified: 2/1/2019
        /// Description: Ask user his/her choice before closing application
        /// </summary>
        public void ContinueAnotherOperation()
        {
            try
            {
                Console.WriteLine("Do you want to perform another file operation? Please Press 'Y' to Continue.");

                if (Console.ReadLine().ToUpper() == "Y")
                {
                    CaptureUserInput();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                adapter.Log(ex);
                throw new Exception("Application error has occured.Please try after sometime.");

            }
        }

        /// <summary>
        /// Modified by: Akshay Pisal
        /// Last Modified: 2/1/2019
        /// Description: Based on user inputs function returns version or size of file specified in command.
        /// </summary>
        /// 
        public string FileOperator(string strInput)
        {
            try
            {
                string[] strData = strInput.Split(' ');
                ThirdPartyTools.FileDetails objFileDetails = new ThirdPartyTools.FileDetails();

                string[] VersionFormats = ConfigurationManager.AppSettings["VersionArray"].Split(',');
                string[] SizeFormats = ConfigurationManager.AppSettings["SizeArray"].Split(',');
                if (strData.Length != 2)
                {
                    return "Input is invalid. Please specify only two parameters.";
                }

                if (VersionFormats.Contains(strData[0].Trim()))
                {
                    return "File Version : " + objFileDetails.Version(strData[1].Trim());
                }

                if (SizeFormats.Contains(strData[0].Trim()))
                {
                    return "File Size : " + Convert.ToString(objFileDetails.Size(strData[1].Trim()));
                }

                return "Command does not exists. Please verify command and try again.";

            }
            catch (IndexOutOfRangeException ex)
            {
                adapter.Log(ex);
                return "Application Exception has occured. Please Contact System Admin.";
            }
            catch (NullReferenceException exRef)
            {
                adapter.Log(exRef);
                return "Application error has occured.Please try after sometime.";
            }
            catch (System.IO.IOException exIo)
            {
                adapter.Log(exIo);
                return "File operation failed. Please confirm file path.";
            }
            catch (Exception ex)
            {
                adapter.Log(ex);
                return "Application error has occured.Please try after sometime.";
            }
        }        
    }
}
