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

    /// <summary>
    /// Инициализация таблицы Products
    /// </summary>
    public class ProductDbInitializer : DropCreateDatabaseAlways<ProductContext>
    {
        protected override void Seed(ProductContext db)
        {
            db.Products.Add(new Product { Name = "ASUS MAXIMUS VII RANGER", selectedCategory = "Материнские платы", Description = "Супер современная материнская плата", Characteristics = "Тут будут характеристики", Price = 3509, Tags = "fast, superspeed, ultramodern", DateAdd = "2017-01-14", Image = "motherB.jpg", ManufacturerId = 1 });
            db.Products.Add(new Product { Name = "KINGSTON USB FLASH 32GB", selectedCategory = "Накопители", Description = "Ультрабыстрый флэш-накопитель.", Characteristics = "Тут будут характеристики", Price = 322, Tags = "flash, fast, superspeed", DateAdd = "2017-01-19", Image = "flashK.jpg", ManufacturerId = 2 });
            db.Products.Add(new Product { Name = "A4 Tech A4-KB-28G-1-U", selectedCategory = "Клавиатуры", Description = "Самая надежная клавиатура.", Characteristics = "Тут будут характеристики", Price = 202, Tags = "a4, keyboard, usb", DateAdd = "2017-01-20", Image = "a4Keyb.jpg", ManufacturerId = 3 });
            db.Products.Add(new Product { Name = "Logitech G105 USB", selectedCategory = "Клавиатуры", Description = "Игровая клавиатура с подцветкой.", Characteristics = "Тут будут характеристики", Price = 901, Tags = "logitech, keyboard, usb, backlight", DateAdd = "2017-01-22", Image = "logG105Keyb.jpg", ManufacturerId = 4 });
            db.Products.Add(new Product { Name = "INTEL I7-4790 LGA1150, 3.5GHz", selectedCategory = "Процессоры", Description = "Мощнейший процессор седьмого поколения.", Characteristics = "Производитель Intel Семейство Intel Core I7 Ядро Haswell Сокет 1150 Тактовая частота 3.6 ГГц", Price = 4620, Tags = "intel, i7, cpu, LGA1150", DateAdd = "2017-01-29", Image = "intel_I7.jpg", ManufacturerId = 5 });

            db.Manufacturers.Add(new Manufacturer { Name = "ASUS" });
            db.Manufacturers.Add(new Manufacturer { Name = "KINGSTON" });
            db.Manufacturers.Add(new Manufacturer { Name = "A4 Tech" });
            db.Manufacturers.Add(new Manufacturer { Name = "Logitech" });
            db.Manufacturers.Add(new Manufacturer { Name = "INTEL" });

            base.Seed(db);
        }
    }
}