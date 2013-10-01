using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MongoLabSurveyor.Resources;
using MongoLabSurveyor.Model;
using System.IO.IsolatedStorage;
using MongoLabSurveyor.Service;

namespace MongoLabSurveyor.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private string apikey;
        public string ApiKey
        {
            get
            {
                return apikey;
            }
            set
            {
                apikey = value;
                RaisePropertyChanged("ApiKey");
            }
        }

        public void GetDatabases()
        {
            GetDefaultDatabases();
        }

        public async void GetDefaultDatabases()
        {
           
        }

        
    }
}