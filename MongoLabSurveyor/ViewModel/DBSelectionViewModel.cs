﻿using System.Collections;
using System.Collections.Generic;
using MongoLabSurveyor.Contracts;

namespace MongoLabSurveyor.ViewModel
{
    public class DBSelectionViewModel : ViewModelBase
    {
        private IMongoLabDataService _mongoLabDataService;

        private ICollection<string> _dbCollection;

        public ICollection<string> DbCollection
        {
            get
            {
                return _mongoLabDataService.GetDatabases() as ICollection<string>;
            }
        } 

        public DBSelectionViewModel(IMongoLabDataService mongoLabDataService)
        {
            _mongoLabDataService = mongoLabDataService;
        }
    }
}
