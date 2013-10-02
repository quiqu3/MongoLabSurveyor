namespace MongoLabSurveyor.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using System.Windows;

    public class NavigationService : INavigationService
    {
        public bool Navigate(Uri source)
        {
            var rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
            return rootFrame.Navigate(source);
        }

        public void GoBack()
        {
            var rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
