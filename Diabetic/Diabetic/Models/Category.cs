using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Diabetic.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public List<Product> Products { get; set; }

        public Category(int id, string name, List<Product> products,ImageSource source)
        {
            Id = id;
            Name = name;
            Products = products;
            Image = source;
        }
    }
}