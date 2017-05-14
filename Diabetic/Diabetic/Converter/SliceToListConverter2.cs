﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Diabetic.Models;
using Diabetic.Utils;
using Diabetic.Views;
using Xamarin.Forms;

namespace Diabetic.Converter
{
    public class SliceToListConverter2 : IValueConverter
    {
        public static List<List<T>> Split<T>(IList<T> source, List<Product> products )
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / (int)Math.Ceiling((double)products.Count / (double)3))
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;




            if (value != null && parameter != null)
            {

                var d = new ObservableCollection<Product>((ObservableCollection<Product>)value);

                var dd = Split(d,d.ToList());
                if (int.Parse(parameter.ToString()) > dd.Count - 1)
                {
                    return null;
                }


                return Split(d,d.ToList())[int.Parse(parameter.ToString())];
              

            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}