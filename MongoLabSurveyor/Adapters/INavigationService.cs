namespace MongoLabSurveyor.Adapters
{
    using Microsoft.Phone.Controls;
    using System;
    using System.Windows.Navigation;

    public interface INavigationService
    {
        bool CanGoBack { get; }
        bool Navigate(Uri source);
        void GoBack();
        event NavigatedEventHandler Navigated;
        event NavigatingCancelEventHandler Navigating;
        event EventHandler<ObscuredEventArgs> Obscured;
        bool RecoveredFromTombstoning { get; set; }
        void UpdateTombstonedPageTracking(Uri pageUri);
        bool DoesPageNeedtoRecoverFromTombstoning(Uri pageUri);
    }
}
