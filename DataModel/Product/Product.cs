using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel
{
    public class Product
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        public string Characteristics { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Теги товара
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Дата добавления товара
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Название изображения товара
        /// </summary>
        public string Image { get; set; }

        public Category Category { get; set; }
        /// <summary>
        /// Id категории
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Id производителя
        /// </summary>
        public Manufacturer Manufacturer { get; set; }

        public int ManufacturerId { get; set; }

        public List<Cart> Cart { get; set; }

    }

}