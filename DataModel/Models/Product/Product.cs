using System;
using System.Collections.Generic;

/// <summary>
/// Содержит модели таблиц базы данных
/// </summary>
namespace DataModel.Models
{
    /// <summary>
    /// Класс модели товаров
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Описание товара
        /// </summary>
        /// <value>Описание</value>
        public string Description { get; set; }
        /// <summary>
        /// Характеристики товара
        /// </summary>
        /// <value>Характеристики</value>
        public string Characteristics { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        /// <value>Цена</value>
        public int Price { get; set; }
        /// <summary>
        /// Теги товара
        /// </summary>
        /// <value>Теги</value>
        public string Tags { get; set; }
        /// <summary>
        /// Дата добавления товара
        /// </summary>
        /// <value>Дата добавления</value>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Название изображения товара
        /// </summary>
        /// <value>Название изображения</value>
        public string Image { get; set; }
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        /// <value>Идентификатор категории</value>
        public int CategoryId { get; set; }
        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        /// <value>Идентификатор производителя</value>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Ссылка на категории
        /// </summary>
        /// <value>Категории</value>
        public Category Category { get; set; }
        /// <summary>
        /// Ссылка на производителей
        /// </summary>
        /// <value>Производители</value>
        public Manufacturer Manufacturer { get; set; }
        /// <summary>
        /// Ссылка на список товаров в заказе
        /// </summary>
        /// <value>Список товаров в заказе</value>
        public List<OrderProduct> OrderProduct { get; set; }

    }

}