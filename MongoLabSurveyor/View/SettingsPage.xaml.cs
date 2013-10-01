using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MongoLabSurveyor.Service;
using MongoLabSurveyor.ViewModel;

namespace MongoLabSurveyor.View
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        SettingsViewModel vm = new SettingsViewModel(new StorageService());

        public SettingsPage()
        {
            InitializeComponent();

            vm = new SettingsViewModel(new StorageService());

            vm.ReadSetting();

            this.DataContext = vm;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            vm.SaveSetting();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            
        }
    }
}