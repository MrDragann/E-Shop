using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel
{
    /// <summary>
    /// Модель категорий
    /// </summary>
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Parent { get; set; }

        public int? ParentId { get; set; }

        public List<Category> Сhild { get; set; }

        public List<Product> Products { get; set; }

        
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}