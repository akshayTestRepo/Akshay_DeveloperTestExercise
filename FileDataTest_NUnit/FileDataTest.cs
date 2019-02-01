using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileData;
using NUnit.Framework;


namespace FileDataTest_NUnit
{
    [TestFixture]
    public class FileDataTest
    {
        [TestCase("--size c:/test.txt", Description = "PASS test", TestName = "GetFileSize", ExpectedResult = "File Size")]
        [TestCase("--version c:/test.txt", Description = "PASS test", TestName = "GetFileVersion", ExpectedResult = "File Version")]
        [TestCase("version", Description = "Failure test", TestName = "InvalidInput", ExpectedResult = "Invalid Input")]
        [TestCase("version c:/test.txt", Description = "Failure test", TestName = "InvalidCommand", ExpectedResult = "Command does not exists")]
        public string FileOperatorTestValidSize(string userinput)
        {
            FileOperations objResult = new FileOperations("FA");

            string testResponse = string.Empty;
            string strResult = objResult.FileOperator(userinput);

            if (strResult.Contains("File Size"))
                testResponse = "File Size";
            else if (strResult.Contains("File Version"))
                testResponse = "File Version";
            else if (strResult == "Input is invalid. Please specify only two parameters.")
                testResponse = "Invalid Input";
            else if (strResult == "Command does not exists. Please verify command and try again.")
                testResponse = "Command does not exists";

            return testResponse;

        }

    }
}
