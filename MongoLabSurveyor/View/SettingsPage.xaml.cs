﻿using System;
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
        public SettingsPage()
        {
            InitializeComponent();

            //vm = new SettingsViewModel(new SettingsStore(), new MongoLabSurveyor.Adapters.ApplicationFrameNavigationService());

            //vm.ReadSetting();

            //this.DataContext = vm;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ((SettingsViewModel)DataContext).SaveSetting();
        }
    }
}