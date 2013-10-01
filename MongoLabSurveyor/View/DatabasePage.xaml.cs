using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MongoLabSurveyor.ViewModels;

namespace MongoLabSurveyor.View
{
    public partial class DatabasesPage : PhoneApplicationPage
    {
        public DatabasesPage()
        {
            InitializeComponent();
            DatabaseViewModel productViewModel = new DatabaseViewModel();

            productViewModel.GetDatabases();

            this.DataContext = productViewModel;
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }
    }
}