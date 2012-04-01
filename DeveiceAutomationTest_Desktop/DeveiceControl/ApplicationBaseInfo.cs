using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveiceAutomationTest_Desktop.DeveiceControl
{
    public class ApplicationBaseInfo
    {
        public string XapFilePath { get; set; }
        public string IconFilePath { get; set; }
        public Guid ApplicationGuid { get; set; }

        public ApplicationBaseInfo(string xapFilePath, string iconFilePath, Guid applicationGuid)
        {
            if (!string.IsNullOrEmpty(applicationGuid.ToString()))
            {
                this.XapFilePath = xapFilePath;
                this.IconFilePath = iconFilePath;
                this.ApplicationGuid = applicationGuid;
            }
        }
    }
}
