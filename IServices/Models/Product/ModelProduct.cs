using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    public class ModelProduct
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
        /// Выбранная категория
        /// </summary>
        public string CategoryName { get; set; }
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
        public string DateAdd { get; set; }
        /// <summary>
        /// Название изображения товара
        /// </summary>
        public string Image { get; set; }
    }
}
