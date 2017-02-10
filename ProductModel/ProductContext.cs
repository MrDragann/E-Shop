using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    /// <summary>
    /// Контекст данных для работы с моделями
    /// </summary>
    public class ProductContext : DbContext
    {
        public ProductContext()
        : base("DefaultConnection")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }

    
}