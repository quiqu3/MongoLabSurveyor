namespace MongoLabSurveyor.ViewModel
{
    using Contracts;
using Microsoft.Phone.Tasks;
using MongoLabSurveyor.Adapters;
using MongoLabSurveyor.Commands;
using System.IO.IsolatedStorage;

    public class SettingsViewModel : ViewModel
    {
        private readonly ISettingsStore settingsStore;
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

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SubmitCommand { get; set; }
        public DelegateCommand GoMongoLabLoginCommand { get; set; }

        public SettingsViewModel(ISettingsStore settingsStore, INavigationService navigationService)
            : base (navigationService)
        {
            this.settingsStore = settingsStore;

            this.CancelCommand = new DelegateCommand(this.Cancel);
            this.SubmitCommand = new DelegateCommand(this.Submit);
            this.GoMongoLabLoginCommand = new DelegateCommand(this.GoMongoLabLogin);

            ReadSetting();
        }
        
        public void Cancel()
        {
            this.NavigationService.GoBack();
        }
        
        public void Submit()
        {
            SaveSetting();

            this.NavigationService.GoBack();
        }

        public void GoMongoLabLogin()
        {
            WebBrowserTask wbtask = new WebBrowserTask();
            wbtask.Uri = new System.Uri("https://mongolab.com/login/");
            wbtask.Show();
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