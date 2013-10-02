namespace MongoLabSurveyor.Adapters
{
    using Microsoft.Phone.Controls;
    using System;
    using System.Windows.Navigation;

    public interface INavigationService
    {
        bool Navigate(Uri source);
        void GoBack();
    }
}
