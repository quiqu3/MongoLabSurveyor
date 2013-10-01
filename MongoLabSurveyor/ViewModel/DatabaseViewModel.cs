﻿namespace MongoLabSurveyor.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Model;

    public class DatabaseViewModel : ViewModelBase
    {
        private IMongoLabDataService _mongoLabDataService;

        public DatabaseViewModel(IMongoLabDataService mongoLabDataService)
        {            
            _mongoLabDataService = mongoLabDataService;
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

        public void GetDatabases()
        {
            GetDefaultDatabases();
        }

        public async void GetDefaultDatabases()
        {
            var dbs = new ObservableCollection<MongoLabDB>();

            var databases = await _mongoLabDataService.GetDatabases();

            databases.ToList().ForEach(async dbname => dbs.Add(new MongoLabDB() { Name = dbname, Collections = await mongoLabDataService.GetDbStats(dbname) }));

            Databases = dbs;
        }

        
    }
}