namespace MongoLabSurveyor.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Model;
    using System;
    using MongoLabSurveyor.Adapters;
    using MongoLabSurveyor.Commands;

    public class DatabaseViewModel : ViewModel
    {
        private const string ERROR_INVALIDAPIKEY = "Error loading data. Please ensure that your device is connected to the network and the API key is correct.";
        private const string ERROR_MISSINGAPIKEY = "The API Key is not configured. Please select the settings option in the App bar and enter a valid API key.";

        private readonly IMongoLabDataService mongoLabDataService;
        private readonly ISettingsStore settingsStore;
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AboutCommand { get; set; }
        public DelegateCommand SettingsCommand { get; set; }
        public DelegateCommand RepairDatabaseCommand { get; set; }

        public DatabaseViewModel(ISettingsStore settingsStore, IMongoLabDataService mongoLabDataService, INavigationService navigationService)
            : base(navigationService)
        {
            this.mongoLabDataService = mongoLabDataService;
            this.settingsStore = settingsStore;

            databases = new ObservableCollection<MongoLabDB>();

            this.RefreshCommand = new DelegateCommand(this.Refresh);
            this.AboutCommand = new DelegateCommand(this.About);
            this.SettingsCommand = new DelegateCommand(this.Settings);
            this.RepairDatabaseCommand = new DelegateCommand(this.RepairDatabase);

            Refresh();
        }

        private readonly ObservableCollection<MongoLabDB> databases;
        public ObservableCollection<MongoLabDB> Databases
        {
            get
            {
                return databases;
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

        private int selectedPivotIndex;
        public int SelectedPivotIndex
        {
            get
            {
                return selectedPivotIndex;
            }
            set
            {
                selectedPivotIndex = value;
                RaisePropertyChanged("SelectedPivotIndex");
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

        private string progressMessage;
        public string ProgressMessage
        {
            get
            {
                return progressMessage;
            }
            set
            {
                progressMessage = value;
                RaisePropertyChanged("ProgressMessage");
            }
        }

        public void Refresh()
        {
            SelectedPivotIndex = 0;

            ErrorMessage = null;

            Databases.Clear();

            if (settingsStore.ApiKey != String.Empty)
            {
                GetDefaultDatabases();
            }
            else
            {
                ErrorMessage = ERROR_MISSINGAPIKEY;
            }
        }

        public void About()
        {
            NavigationService.Navigate(new Uri("/View/AboutPage.xaml", UriKind.Relative));
        }

        public void Settings()
        {
            NavigationService.Navigate(new Uri("/View/SettingsPage.xaml", UriKind.Relative));
        }

        public async void RepairDatabase()
        {
            try
            {
                IsLoading = true;
                ProgressMessage = "Repairing...";

                var currentDb = Databases[selectedPivotIndex];
                var resp = await mongoLabDataService.SendRepairDatabase(currentDb.Name);
            }
            catch (Exception ex)
            {
                ErrorMessage = ERROR_INVALIDAPIKEY;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void GetDefaultDatabases()
        {
            try
            {
                ProgressMessage = "Refreshing...";
                IsLoading = true;

                var databases = await mongoLabDataService.GetDatabases();

                databases.ToList().ForEach(async dbname => Databases.Add(new MongoLabDB() { Name = dbname, DbStats = await mongoLabDataService.GetDbStats(dbname) }));
            }
            catch (Exception ex)
            {
                ErrorMessage = ERROR_INVALIDAPIKEY;
            }
            finally
            {
                IsLoading = false;
            }
        }


    }
}