using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    

    public class ProductData
    {
        /// <summary>
        /// Экземпляр хранилища товаров
        /// </summary>
        public static ProductData Instance = new ProductData();
        /// <summary>
        /// Коллекция тегов
        /// </summary>
        public static List<string> collectionsTags = new List<string>();
        /// <summary>
        /// Разбиение строки тегов
        /// </summary>
        /// <param name="model">Экземпляр ProductModel</param>
        /// <returns>Коллекцию тегов</returns>
        public List<string> TagsSplit(Product model)
        {
            return model.Tags.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        /// <summary>
        /// Путь к изображениям
        /// </summary>
        public static string pathToImage = "/Content/Images/";
        /// <summary>
        /// Данные для постраничного вывода
        /// </summary>
        public int PageSize = 3;
        public int PageNum { get; set; }
        public int ItemsCount { get; set; }

        /// <summary>
        /// Список категорий
        /// </summary>
        public static List<Category> Category = new List<Category>()
        {
            new Category
            {
                Id = 1,
                Name = "Телефоны",
                Childrens = new List<Category>()
                {
                    new Category
                    {
                        Name = "Смартфоны"
                    },
                    new Category
                    {
                        Name = "Радио телефоны"
                    }
                }
            },
            new Category
            {
                Id = 2,
                Name = "Ноутбуки"
            },
            new Category
            {
                Id = 3,
                Name = "Планшеты"
            },
            new Category
            {
                Id = 4,
                Name = "Аксессуары",
                Childrens = new List<Category>()
                {
                    new Category
                    {
                        Name = "Аккумуляторы"
                    },
                    new Category
                    {
                        Name = "Память"
                    },
                    new Category
                    {
                        Name = "Аудио"
                    }
                }
            }
        };
        
    }
    public enum TypeSort
    {
        NameAsc,
        NameDesc,
        PriceAsc,
        PriceDesc
    }
}