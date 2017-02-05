namespace ProductModel.Migrations
{
    using Shop.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductContext context)
        {
            context.Products.AddOrUpdate(
              p => p.Id,
              new Product { Name = "ASUS MAXIMUS VII RANGER", selectedCategory = "Материнские платы", Description = "Супер современная материнская плата", Characteristics = "Тут будут характеристики", Price = 3509, Tags = "fast, superspeed, ultramodern", DateAdd = "2017-01-14", Image = "motherB.jpg", ManufacturerId = 1 },
              new Product { Name = "KINGSTON USB FLASH 32GB", selectedCategory = "Накопители", Description = "Ультрабыстрый флэш-накопитель.", Characteristics = "Тут будут характеристики", Price = 322, Tags = "flash, fast, superspeed", DateAdd = "2017-01-19", Image = "flashK.jpg", ManufacturerId = 2 },
              new Product { Name = "A4 Tech A4-KB-28G-1-U", selectedCategory = "Клавиатуры", Description = "Самая надежная клавиатура.", Characteristics = "Тут будут характеристики", Price = 202, Tags = "a4, keyboard, usb", DateAdd = "2017-01-20", Image = "a4Keyb.jpg", ManufacturerId = 3 },
              new Product { Name = "Logitech G105 USB", selectedCategory = "Клавиатуры", Description = "Игровая клавиатура с подцветкой.", Characteristics = "Тут будут характеристики", Price = 901, Tags = "logitech, keyboard, usb, backlight", DateAdd = "2017-01-22", Image = "logG105Keyb.jpg", ManufacturerId = 4 },
              new Product { Name = "INTEL I7-4790 LGA1150, 3.5GHz", selectedCategory = "Процессоры", Description = "Мощнейший процессор седьмого поколения.", Characteristics = "Производитель Intel Семейство Intel Core I7 Ядро Haswell Сокет 1150 Тактовая частота 3.6 ГГц", Price = 4620, Tags = "intel, i7, cpu, LGA1150", DateAdd = "2017-01-29", Image = "intel_I7.jpg", ManufacturerId = 5 }
            );

            context.Manufacturers.AddOrUpdate(p => p.Id,
              new Manufacturer { Name = "ASUS" },
              new Manufacturer { Name = "KINGSTON" },
              new Manufacturer { Name = "A4 Tech" },
              new Manufacturer { Name = "Logitech" },
              new Manufacturer { Name = "INTEL" }
                );
        }
    }
}
