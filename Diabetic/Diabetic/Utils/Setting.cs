using System;
using System.IO;
using Diabetic.Models;
using Xamarin.Forms;

namespace Diabetic.Utils
{
    public static class Setting
    {
        public static int CurrentChoiceLaunch = 0;
        public static int CurrentRestaurant = 0;
        public static T Clone<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            // In the PCL we do not have the BinaryFormatter
            return source;
        }
        public static DataSugar DataSugarChoice { get; set; }
        public  static User User { get; set; }
        public const string UrlAddressToGeoPoint = "https://maps.google.com/maps/api/geocode/json?address=";
        public const string PathRessources = "Diabetic.";

        public static string[] Restaurants = new[]
        {
            "Mcdo","Kfc"
        };
        public static string PathImage { get; } = PathRessources + "Assets.Img.";

        public static string[] Categories = new[]
        {
            @"1,Sandwiches
2,Petite Faim
3,Boissons
4,Desserts
5,Happy Meal",
            @"1,Buckets
2,Sandwiches
3,Salades
4,Pieces de poulet
5,Accompagnements
6,Desserts
7,Boisson froides
8,Boisson chaudes
9,Ze Bag"

        };

        public static string[] Products = new[]
        {
            @"Hamburger, 23, 7, 1
Cheeseburger, 23, 7, 1
Chicken McNuggets (4 morceaux), 12, 0, 1
McFish, 31, 8, 1
Croque McDo, 23, 4, 1
Frite petite, 29, 0, 2
Potatoes moyenne, 27, 0, 2
P'tites tomates, 0, 2, 2
Coca-cola (25cl), 0, 27, 3
Ice Tea (25cl), 0, 16, 3
Minute Maid (20cl), 1, 21, 3
McFlurry Granola, 7, 36, 4
Frappé Vanille Fraise, 3, 35, 4
P'tite pomme, 0, 9, 4
Muffin Chocolat, 16, 23, 4
4 Chicken nuggets,12,0,5
Cheesburger,23,7,5
Hamburger,23,7,5
Croque McDo,23,4,5
McFish,31,8,5
Petites Tomates,0,2,5
Moyenne Deluxe Potatoes,27,0,5
Petite Frite,29,0,5
Mon P'tit Jus Bio,0,24,5
Evian 33cl,0,0,5
Petit Liption Ice-Tea,0,16,5
Petit Sprite,0,16,5
Petit Fante,0,23,5
Petit Coca-Cola Light,0,0,5
Petit Coca-Cola Zero,0,0,5
Petit Coca-Cola,0,27,5
Minute Maid Orange 30cl,1,21,5
P'tit Ananas,0,8,5
Berlingo' Fruits Pomme,1,13,5
Mon Bio a Boire Vanille,1,9,5
P'tite Pomme,0,9,5",
            @"Duo Tenders,30.9,0.1,1
Maxi Tenders,25.9,0.1,1
Krunchy sauce burger,25,4,2
Twister Tenders,26,1,2
Tower Original,59,10,2
Salade Ceasar Poulet cuit au four(sans sauce),12,7,3
Tenders 4,20.9,1,4
Wings Hot 6,21.9,0.1,4
Frites normales salees,34,1,5
Frites grandes salees,49,1,5
Sundea caramel,6,30,6
Mini cookies,7,9,6
Tiramisu,7,15,6
Orangina 33cl,0,33,7
Pepsi 33cl,0,36,7
5 Tomates Cerise,2,3,9
3 Crispy Tenders,20.9,0.1,9
2 Pilons de Poulet,10.9,0.1,9
Bazik,30,7,9
3 Fish Tenders,18,0,9
Petite frite,32,0,9
Cobette,22,4,9
Petit Yaourt,1,12,9
Sundae,6,23,9"

        };

        public static ImageSource GetImage(string img)
        {
           return ImageSource.FromResource($"Diabetic.Assets.Img.{img}");
        }
    }
}