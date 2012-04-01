using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
//using System.ServiceModel;
using Microsoft.SmartDevice.Connectivity;
using System.ServiceModel;
using DeveiceAutomationTest_Desktop.DeveiceControl;
using DeveiceAutomationTest_Desktop.ReportService;

namespace DeveiceAutomationTest_Desktop
{
    class Program
    {
        static AutoResetEvent lastendTestRunEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            //Base ApplicationInfo
            string xapfile = @"..\..\..\WP7AutomationTest_Demo.Test\Bin\Debug\WP7AutomationTest_Demo.Test.xap";
            string iconfile = @"..\..\..\WP7AutomationTest_Demo.Test\Bin\Debug\WApplicationIcon.png";
            ApplicationBaseInfo currentBaseInfo = new ApplicationBaseInfo(xapfile, iconfile, new Guid("b81d87a6-3afd-4f21-9a60-3c5ae0921fd2"));

            //DeviceManager Object
            Device deviceObj = DeviceManager.GetSupportPlatformDeviceObj(1031,false);
            using (ServiceHost currentHost = new ServiceHost(typeof(TestResultReportService)))
            {
                currentHost.Open();
                Console.WriteLine("Current Service is Open...");
                Console.WriteLine("Connecting to Windows phone Emluator Device...");

                try
                {
                    //Device Connection
                    deviceObj.Connect();
                    Console.WriteLine("Windows phone Emluator Device Connected...");
                    ApplicationManager.InstallApplicationAndLaunch(deviceObj, currentBaseInfo.ApplicationGuid, currentBaseInfo.IconFilePath, currentBaseInfo.XapFilePath);
                    Console.WriteLine("Wait For Run TestCase Compated...");

                    lastendTestRunEvent.WaitOne(12000);

                    Console.WriteLine("Test Case is Run Complate...");
                    ApplicationManager.UnstallApplicationAndClear(deviceObj, currentBaseInfo.ApplicationGuid);
                    Console.WriteLine("Application is UnStall and Clear...");                   
                }
                finally
                {
                    deviceObj.Disconnect();
                }

                //currentHost.Close();
            }
        }

        public static void EndTestRun()
        {
            lastendTestRunEvent.Set();
        }


        
    }
}
