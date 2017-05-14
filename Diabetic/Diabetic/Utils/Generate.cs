using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Diabetic.Models;
using Xamarin.Forms;

namespace Diabetic.Utils
{
    public static class Generate
    {
        public static List<Restaurant> GenerateRestaurant()
        {
            var restaurant = new List<Restaurant>();
            for (int i = 0; i < Setting.Restaurants.Length; i++)
            {
                restaurant.Add(new Restaurant(new Guid(), Setting.Restaurants[i], new List<Category>()));
                String[] substringscat = Setting.Categories[i].Split('\n');
                Dictionary<int, Category> catMacDo =
                    substringscat.Select(line => line.Split(','))
                        .ToDictionary(lineSplit => int.Parse(lineSplit[0]),
                            lineSplit => new Category(int.Parse(lineSplit[0]), lineSplit[1], new List<Product>(), ImageSource.FromResource($"{Setting.PathImage}cat{i}.{lineSplit[0]}.png")));
                substringscat = Setting.Products[i].Split('\n');
                var count = 0;
                foreach (string[] lineSplit in substringscat.Select(line => line.Split(',')))
                {
                    var dd = double.Parse(lineSplit[2], CultureInfo.InvariantCulture);
                    catMacDo[int.Parse(lineSplit[3].Replace("\r",""))].Products.Add(new Product(Guid.NewGuid(), lineSplit[0],
                        double.Parse(lineSplit[1], CultureInfo.InvariantCulture), double.Parse(lineSplit[2],CultureInfo.InvariantCulture), ImageSource.FromResource($"{Setting.PathImage}{i}.{count}.png")));
                    count++;

                }

                foreach (var key in catMacDo)
                {
                    restaurant[i].Categories.Add(key.Value);
                }

            }
            return restaurant;





            //catMacDo[1].Products.Add;
            // return catMacDo;
        }


    }
}