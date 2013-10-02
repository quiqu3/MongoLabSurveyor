namespace MongoLabSurveyor.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Model;
    using System;
    using MongoLabSurveyor.Adapters;

    public class DatabaseViewModel : ViewModel
    {
        private const string ERROR_INVALIDAPIKEY = "error loading data. please ensure that your device is connected to the network and the api key is correct.";
        private const string ERROR_MISSINGAPIKEY = "The Api Key is not configured. Please enter settings and enter the valid api key.";

        private readonly IMongoLabDataService mongoLabDataService;
        private readonly ISettingsStore settingsStore;

        public DatabaseViewModel(ISettingsStore settingsStore, IMongoLabDataService mongoLabDataService, INavigationService navigationService)
            : base(navigationService)
        {
            this.mongoLabDataService = mongoLabDataService;
            this.settingsStore = settingsStore;

            Refresh();
        }

        private ObservableCollection<MongoLabDB> _databases;
        public ObservableCollection<MongoLabDB> Databases
        {
            get
            {
                return _databases;
            }
            set
            {
                _databases = value;
                RaisePropertyChanged("Databases");
            }
        }
        
        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        public void Refresh()
        {
            if (settingsStore.ApiKey != String.Empty)
            {
                GetDefaultDatabases();
            }
            else
            {
                ErrorMessage = ERROR_MISSINGAPIKEY;
            }
        }

        private async void GetDefaultDatabases()
        {
            var dbs = new ObservableCollection<MongoLabDB>();

            try
            {
                IsLoading = true;

                var databases = await mongoLabDataService.GetDatabases();

                databases.ToList().ForEach(async dbname => dbs.Add(new MongoLabDB() { Name = dbname, DbStats = await mongoLabDataService.GetDbStats(dbname) }));
            }
            catch (Exception ex)
            {
                ErrorMessage = ERROR_INVALIDAPIKEY;
            }
            finally
            {
                Databases = dbs;
                IsLoading = false;
            }
        }


    }
}