namespace MongoLabSurveyor.Contracts
{
    using System;
    using System.Windows.Navigation;

    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Uri uri);
        void GoBack();
    }
}
