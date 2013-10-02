using System;
using System.Windows;
using System.Windows.Data;

namespace MongoLabSurveyor.View.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((value != null) ^ ((parameter != null) && ((string)parameter).Equals("Invert")));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
