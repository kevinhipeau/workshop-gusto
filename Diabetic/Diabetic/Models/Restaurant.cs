using System;
using System.Collections.Generic;

namespace Diabetic.Models
{
    public class Restaurant
    {
        public Guid Id;
        public string Name;

        public List<Category> Categories;

        public Restaurant(Guid id, string name, List<Category> categories)
        {
            Id = id;
            Name = name;
            Categories = categories;
        }
    }
}