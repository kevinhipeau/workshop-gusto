using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diabetic.Converter
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && parameter.GetType() == typeof(string))
            {
                return ImageSource.FromResource($"Diabetic.Assets.Img.{parameter}");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}