using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Web;

namespace DeveiceAutomationTest_Desktop.ReportService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestResultReportService" in both code and config file together.
    [ServiceContract]
    public interface ITestResultReportService
    {
        [OperationContract]
        [WebInvoke(BodyStyle=WebMessageBodyStyle.Wrapped)]
        void SaveTestResultFile(string filename,string filecontent);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        void GetFinalTestResult(bool failure, int failures, int totalScenarios, string message);
    }
}
