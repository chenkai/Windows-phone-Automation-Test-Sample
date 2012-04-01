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

using WP7AutomationTest_Demo.ViewModels;

namespace WP7AutomationTest_Demo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private MainPage_ViewModel currentMain_ViewModel = null;
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.currentMain_ViewModel == null)
                this.currentMain_ViewModel = new MainPage_ViewModel();
            this.currentMain_ViewModel.LoadDefaultCatalogData();
            this.DataContext = currentMain_ViewModel;
        }
    }
}