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

        public void SaveSetting()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            
            if (!settings.Contains("apiKey"))
            {
                settings.Add("apiKey", apikey);
            }
            else
            {
                settings["apiKey"] = apikey;
            }

            settings.Save();

        }

        public void ReadSetting()
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("apiKey"))
            {
                ApiKey = IsolatedStorageSettings.ApplicationSettings["apiKey"] as string;
            }
        }
    }
}