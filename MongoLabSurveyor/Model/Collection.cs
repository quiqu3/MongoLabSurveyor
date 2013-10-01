namespace MongoLabSurveyor.Model
{
    using ViewModel;

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
