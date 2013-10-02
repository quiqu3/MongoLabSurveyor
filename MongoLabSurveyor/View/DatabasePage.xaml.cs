﻿using System;
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
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }

        private void SelectDatabaseMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/DBSelectionPage.xaml", UriKind.Relative));
        }
    }
}