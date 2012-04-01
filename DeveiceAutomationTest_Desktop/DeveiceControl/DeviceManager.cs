using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Add Referencs
using System.Collections.ObjectModel;
using Microsoft.SmartDevice.Connectivity;
namespace DeveiceAutomationTest_Desktop.DeveiceControl
{
    public class DeviceManager
    {
        /// <summary>
        /// Get Current Support Platform Device Object
        /// </summary>
        /// <param name="localId">Region Local Id</param>
        /// <returns>Device Object</returns>
        public static Device GetSupportPlatformDeviceObj(int localId,bool isDevice)
        {
            //Note By chenkai:
            //1033 is the LCID for English, United States and 1031 is the LCID for German, Germany.
            //Please Check List of Locale ID (LCID) Values as Assigned by Microsoft.
            //http://msdn.microsoft.com/zh-cn/goglobal/bb964664.aspx
            //Now Use English is 1031

            if (localId == 0)
                localId = 1031;
            Device currentDeviceObj = null;
            DatastoreManager datastoreManagerObj = new DatastoreManager(localId);
            Platform wp7Platform = datastoreManagerObj.GetPlatforms().Single(p => p.Name == "Windows Phone 7");
            if (wp7Platform != null)
            {
                if (isDevice)
                    currentDeviceObj = wp7Platform.GetDevices().Single(x => x.Name == "Windows Phone Device");
                else
                    currentDeviceObj = wp7Platform.GetDevices().Single(x => x.Name == "Windows Phone Emulator");
            }
            return currentDeviceObj;
        }



        /// <summary>
        /// Connection Emulator Device
        /// </summary>
        /// <param name="deviceObj">Device Object</param>
        /// <param name="applicationGuid">Application Guid</param>
        /// <param name="iconFilePath">IconFile Path</param>
        /// <param name="xapFileName">XapFile Name</param>
        /// <returns>return is Connection Device</returns>
        public static void ConnectionDeviceInstallApp(Device deviceObj,Guid applicationGuid,string iconFilePath,string xapFileName)
        {
            if (!string.IsNullOrEmpty(applicationGuid.ToString()))
            {
                try
                {
                    deviceObj.Connect();
                    ApplicationManager.InstallApplicationAndLaunch(deviceObj, applicationGuid, iconFilePath, xapFileName);
                }
                finally
                {
                    deviceObj.Disconnect();
                }
            }
        }
    }
}
