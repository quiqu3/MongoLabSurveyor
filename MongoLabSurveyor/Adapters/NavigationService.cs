namespace MongoLabSurveyor.Adapters
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using System.Windows;

    public class NavigationService : INavigationService
    {
        PhoneApplicationFrame rootFrame;

        public NavigationService()
        {
            rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
        }
        public bool Navigate(Uri source)
        {
            return rootFrame.Navigate(source);
        }

        public void GoBack()
        {
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
        }
    }
}
