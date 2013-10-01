namespace MongoLabSurveyor.ViewModel
{
    using Contracts;
    using System.IO.IsolatedStorage;

    public class SettingsViewModel : ViewModel
    {
        private readonly ISettingsStore settingsStore;

        private const string ApiKeySetting = "ApiKey";
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

        public SettingsViewModel(ISettingsStore settingsStore, INavigationService navigationService)
            : base (navigationService)
        {
            this.settingsStore = settingsStore;
        }

        public void SaveSetting()
        {
            settingsStore.ApiKey = ApiKey;
        }

        public void ReadSetting()
        {
            ApiKey = settingsStore.ApiKey;
        }
    }
}