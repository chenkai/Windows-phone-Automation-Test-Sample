using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.IO;
using System.ServiceModel.Web;
using System.Reflection;
using System.Configuration;

namespace DeveiceAutomationTest_Desktop.ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestResultReportService" in both code and config file together.
    public class TestResultReportService : ITestResultReportService
    {
        public void SaveTestResultFile(string filename, string filecontent)
        {
            var outputfile = Path.Combine(@"..\..\..\DeveiceAutomationTest_Desktop\Bin\Debug\", filename);
            if (File.Exists(outputfile))
            {
                File.Delete(outputfile);
            }
            File.WriteAllText(outputfile, filecontent);
            Console.WriteLine(filecontent);
        }



        
        public void GetFinalTestResult(bool failure, int failures, int totalScenarios, string message)
        {
            Console.WriteLine(message);
            Program.EndTestRun();
        }
    }
}
