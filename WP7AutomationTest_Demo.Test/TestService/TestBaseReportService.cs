using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Microsoft.Silverlight.Testing;
using Microsoft.Silverlight.Testing.Harness;
using Microsoft.Silverlight.Testing.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WP7AutomationTest_Demo.Test.TestService
{
    public class TestBaseReportService:TestReportingProvider
    {
        UnitTestService.TestResultReportServiceClient reportClient = new UnitTestService.TestResultReportServiceClient();

        public TestBaseReportService(TestServiceProvider serviceProvider) : base(serviceProvider) { }

        public override void ReportFinalResult(Action<ServiceResult> callback, bool failure, int failures, int totalScenarios, string message)
        {
            this.IncrementBusyServiceCounter();
            reportClient.SaveTestResultFileCompleted += (se, x) =>
            {
                this.DecrementBusyServiceCounter();
            };
            reportClient.GetFinalTestResultAsync(failure, failures, totalScenarios, message);
            base.ReportFinalResult(callback, failure, failures, totalScenarios, message);
        }

        public override void WriteLog(Action<ServiceResult> callback, string logName, string content)
        {
            this.IncrementBusyServiceCounter();
            reportClient.SaveTestResultFileCompleted += (s, e) =>
            {
                this.DecrementBusyServiceCounter();
            };
            reportClient.SaveTestResultFileAsync(logName, content);
            base.WriteLog(callback, logName, content);
        }
    }
}
