using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diabetic.Converter
{
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            bool booleanValue = (bool)value;
            return !booleanValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            bool booleanValue = (bool)value;
            return !booleanValue;
        }
    }
}