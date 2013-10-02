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
        private readonly IMongoLabDataService mongoLabDataService;
        private readonly ISettingsStore settingsStore;

        public DatabaseViewModel(ISettingsStore settingsStore, IMongoLabDataService mongoLabDataService, INavigationService navigationService)
            : base (navigationService)
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

        public void Refresh()
        {
            GetDefaultDatabases();
        }

        private async void GetDefaultDatabases()
        {
            if (settingsStore.ApiKey != String.Empty)
            {
                var dbs = new ObservableCollection<MongoLabDB>();

                var databases = await mongoLabDataService.GetDatabases();

                databases.ToList().ForEach(async dbname => dbs.Add(new MongoLabDB() { Name = dbname, DbStats = await mongoLabDataService.GetDbStats(dbname) }));

                Databases = dbs;
            }
        }

        
    }
}