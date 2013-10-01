using System.Collections;
using System.Collections.Generic;
using MongoLabSurveyor.Contracts;

namespace MongoLabSurveyor.ViewModel
{
    public class DBSelectionViewModel : ViewModel
    {
        private IMongoLabDataService _mongoLabDataService;

        private ICollection<string> _dbCollection;

        public ICollection<string> DbCollection
        {
            get
            {
                return _mongoLabDataService.GetDatabases() as ICollection<string>;
            }
            set
            {
                _dbCollection = value;
            }
        } 

        public DBSelectionViewModel(IMongoLabDataService mongoLabDataService, INavigationService navigationService)
            : base (navigationService)
        {
            _mongoLabDataService = mongoLabDataService;
        }
       
    }
}
