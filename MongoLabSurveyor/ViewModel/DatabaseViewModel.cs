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
    public class DatabaseViewModel : ViewModelBase
    {
        private ObservableCollection<MongoLabDB> databases;
        public ObservableCollection<MongoLabDB> Databases
        {
            get
            {
                return databases;
            }
            set
            {
                databases = value;
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
            var service = new MongoLabDataService();
            var databases = await service.GetDatabases();

            databases.ToList().ForEach(async dbname => dbs.Add(new MongoLabDB() { Name = dbname, Collections = await service.GetCollections(dbname) }));

            Databases = dbs;
        }

        
    }
}