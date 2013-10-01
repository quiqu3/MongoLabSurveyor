namespace MongoLabSurveyor.ViewModel
{
    using System.IO.IsolatedStorage;

    public class SettingsViewModel : ViewModelBase
    {
        private string _apikey;
        public string ApiKey
        {
            get
            {
                return _apikey;
            }
            set
            {
                _apikey = value;
                RaisePropertyChanged("ApiKey");
            }
        }

        public void SaveSetting()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            // txtInput is a TextBox defined in XAML.
            if (!settings.Contains("apiKey"))
            {
                settings.Add("apiKey", _apikey);
            }
            else
            {
                settings["apiKey"] = _apikey;
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