using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MongoLabSurveyor.Contracts;
using MongoLabSurveyor.Service;
using MongoLabSurveyor.ViewModel;

namespace MongoLabSurveyor.View
{
    public partial class DatabasesPage : PhoneApplicationPage
    {
        public DatabasesPage()
        {
            InitializeComponent();
            var productViewModel = new DatabaseViewModel(new MongoLabDataService(new StorageService()), new MongoLabSurveyor.Common.NavigationService());

            productViewModel.GetDatabases();

            this.DataContext = productViewModel;
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }
    }
}