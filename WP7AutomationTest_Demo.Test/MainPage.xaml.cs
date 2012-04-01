using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Phone.Shell;
using Microsoft.Silverlight.Testing;
using Microsoft.Silverlight.Testing.Harness;
using Microsoft.Silverlight.Testing.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using WP7AutomationTest_Demo.Test.TestService;

namespace WP7AutomationTest_Demo.Test
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //SystemTray is Unabliave
            SystemTray.IsVisible = false;

            var reportSetting = UnitTestSystem.CreateDefaultSettings();
            if (reportSetting!=null)
            {
                reportSetting.TestService.RegisterService(TestServiceFeature.TestReporting, new TestBaseReportService(reportSetting.TestService));
            }

            var currentMobileTestPage = UnitTestSystem.CreateTestPage() as IMobileTestPage;
            if (currentMobileTestPage != null)
            {
                BackKeyPress += (se, x) => x.Cancel = currentMobileTestPage.NavigateBack();
                (Application.Current.RootVisual as PhoneApplicationFrame).Content = currentMobileTestPage;
            }
        }
    }
}