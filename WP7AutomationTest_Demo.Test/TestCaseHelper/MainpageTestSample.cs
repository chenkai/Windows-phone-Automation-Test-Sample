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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WP7AutomationTest_Demo.ViewModels;

namespace WP7AutomationTest_Demo.Test.TestCaseHelper
{
    [TestClass]
    public class MainpageTestSample : SilverlightTest
    {
        [TestMethod]
        public void AllwaysRight()
        {
            Assert.IsTrue(true, "This is just Test Method No Function!");
        }

        [TestMethod]
        public void DataColIsChanged_Test()
        {
            bool isPropertyChanged = false;
            MainPage_ViewModel currentViewModel = new MainPage_ViewModel();
            currentViewModel.PropertyChanged += (x, se) =>
            {
               if (currentViewModel.CatalogInfoCol.Count > 0)
                   isPropertyChanged = true;
            };
            currentViewModel.CatalogInfoCol = new System.Collections.ObjectModel.ObservableCollection<CatalogInfor>() 
            {
               new CatalogInfor(){CatalogTitle="ComplateTestChanged",CatalogComment="TestData"}
            };
            Assert.IsTrue(isPropertyChanged);
        }
    }
}
