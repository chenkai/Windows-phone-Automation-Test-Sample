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

using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WP7AutomationTest_Demo.ViewModels
{
    public class MainPage_ViewModel:BasicViewModel
    {
        public  ObservableCollection<CatalogInfor> cataologInfoCol = new ObservableCollection<CatalogInfor>();
        public ObservableCollection<CatalogInfor> CatalogInfoCol
        {
            get { return this.cataologInfoCol; }
            set
            {
                this.cataologInfoCol = value;
                base.NotifyPropertyChangedEventHandler("CatalogInfoCol");
            }
        }

        public void LoadDefaultCatalogData()
        {
            this.cataologInfoCol.Clear();
            this.cataologInfoCol.Add(new CatalogInfor() { CatalogTitle="Jack Chen",CatalogComment="Chinese GongFu Supper Start." });
            this.cataologInfoCol.Add(new CatalogInfor() { CatalogTitle = "Eason Chan Yik shun ", CatalogComment = "HK Popular Single." });
        }
    }

    public class CatalogInfor
    {
        public string CatalogTitle{get;set;}
        public string CatalogComment{get;set;}
    }
}
