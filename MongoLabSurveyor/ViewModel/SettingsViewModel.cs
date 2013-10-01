namespace MongoLabSurveyor.ViewModel
{
    using Contracts;
    using System.IO.IsolatedStorage;

    public class SettingsViewModel : ViewModelBase
    {
        private IStorageService _storageService;

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

        public SettingsViewModel(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void SaveSetting()
        {
            _storageService.SaveSetting(ApiKeySetting, _apikey);
        }

        public void ReadSetting()
        {
            ApiKey = _storageService.ReadSetting(ApiKeySetting);
        }
    }
}