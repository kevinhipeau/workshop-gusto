using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diabetic.Converter
{
    public class WidthMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double resultDouble;
            if (value == null)
                return new Thickness(0);
            var result = Double.TryParse(value.ToString(), out resultDouble);
            if (result && resultDouble > 0)
            {
                return new Thickness(resultDouble*-1,0, 0, 0);

            }
            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}