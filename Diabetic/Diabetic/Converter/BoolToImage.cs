using System;
using System.Globalization;
using Diabetic.Utils;
using Xamarin.Forms;

namespace Diabetic.Converter
{
    public class BoolToImage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            bool booleanValue = (bool)value;
            if (booleanValue)
            {
                return Setting.GetImage("boutonins.png");
            }
            else
            {
                return Setting.GetImage("boutoninsno.png");
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}