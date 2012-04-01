using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Add references
using Microsoft.SmartDevice.Connectivity;

namespace DeveiceAutomationTest_Desktop.DeveiceControl
{
    public class ApplicationManager
    {
        /// <summary>
        /// Install Application and Launch Windows phone Simulator
        /// </summary>
        /// <param name="deviceObj">Device Information</param>
        /// <param name="applicationGuid">Application Guid</param>
        /// <param name="iconFileName">Icon FileName[File Path]</param>
        /// <param name="xapFileName">Xap Package FileName</param>
        public static void InstallApplicationAndLaunch(Device deviceObj, Guid applicationGuid, string iconFileName, string xapFileName)
        {
            if (!string.IsNullOrEmpty(applicationGuid.ToString()))
            {
                //Install and Luanch
                UnstallApplicationAndClear(deviceObj, applicationGuid);
                deviceObj.InstallApplication(applicationGuid, applicationGuid, "AutomationAPP", iconFileName, xapFileName);
                RemoteApplication currentApplication = deviceObj.GetApplication(applicationGuid);
                if (currentApplication != null)
                    currentApplication.Launch();
                Console.WriteLine("Install Application is Complated...");
            }
        }


        /// <summary>
        /// Unstall Application and Clear Windows phone Simulator
        /// </summary>
        /// <param name="deviceObj">Device Object Infor</param>
        /// <param name="applicationGuid">Application Guid</param>
        public static void UnstallApplicationAndClear(Device deviceObj, Guid applicationGuid)
        {
            if(!string.IsNullOrEmpty(applicationGuid.ToString()))
            {
                if (deviceObj.IsApplicationInstalled(applicationGuid))
                {
                    RemoteApplication remoteApplication = deviceObj.GetApplication(applicationGuid);
                    if (remoteApplication != null)
                    {
                        //Remove Application
                        remoteApplication.TerminateRunningInstances();
                        remoteApplication.Uninstall();
                        Console.WriteLine("UnInstall Application is Complated...");
                    }
                }
            }
    
        }
    }
}
