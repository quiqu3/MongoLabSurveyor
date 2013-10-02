using System;
using System.Collections.ObjectModel;
using System.Linq;
using MongoLabSurveyor.Model;

namespace MongoLabSurveyor.ViewModel
{
    using System.Collections.Generic;
    using Contracts;
    using Adapters;

    public class DBSelectionViewModel : ViewModel
    {
        private IMongoLabDataService _mongoLabDataService;
        private ISettingsStore _settingsStore;

        private ObservableCollection<string> _dbCollection;
        public ObservableCollection<string> DbCollection
        {
            get
            {
                return _dbCollection;
            }
            set
            {
                _dbCollection = value;
                RaisePropertyChanged("DbCollection");
            }
        }       

        public DBSelectionViewModel(IMongoLabDataService mongoLabDataService, INavigationService navigationService, ISettingsStore settingsStore)
            : base (navigationService)
        {
            _mongoLabDataService = mongoLabDataService;
            _settingsStore = settingsStore;

            Refresh();
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

        public void Refresh()
        {
            GetDefaultDatabases();
        }

        private async void GetDefaultDatabases()
        {
            if (_settingsStore.ApiKey != String.Empty)
            {
                IsLoading = true;

                var dbs = new ObservableCollection<string>();

                var databases = await _mongoLabDataService.GetDatabases();

                if (databases != null)
                {
                    foreach (var database in databases)
                    {
                        dbs.Add(database);
                    }
                }

                DbCollection = dbs;

                IsLoading = false;
            }
        }

        public void SaveSelection()
        {
            throw new NotImplementedException();
        }
    }
}
