using MongoLabSurveyor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoLabSurveyor.Model
{
    public class Collection : ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private int total;
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                RaisePropertyChanged("Total");

            }
        }
    }
}
