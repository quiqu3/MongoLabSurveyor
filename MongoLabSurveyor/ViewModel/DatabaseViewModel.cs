namespace MongoLabSurveyor.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using Contracts;
    using Model;

    public class DatabaseViewModel : ViewModel
    {
        private readonly IMongoLabDataService _mongoLabDataService;

        public DatabaseViewModel(IMongoLabDataService mongoLabDataService, INavigationService navigationService)
            : base (navigationService)
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

            databases.ToList().ForEach(async dbname => dbs.Add(new MongoLabDB() { Name = dbname, DbStats = await _mongoLabDataService.GetDbStats(dbname) }));

            Databases = dbs;
        }

        
    }
}