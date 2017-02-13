using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Childrens { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}