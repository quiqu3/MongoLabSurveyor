namespace MongoLabSurveyor.ViewModel
{
    using MongoLabSurveyor.Contracts;
    using System.ComponentModel;

    public abstract class ViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService navigationService;

        protected ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public INavigationService NavigationService
        {
            get { return this.navigationService; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
