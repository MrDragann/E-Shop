using System;
using System.Web;

/// <summary>
/// Содержит модели для работы с базой данных
/// </summary>
namespace IServices.Models
{
    /// <summary>
    /// Класс модели товаров
    /// </summary>
    public class ModelProduct
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
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        public HttpPostedFileBase file { get; set; }
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        /// <value>Идентификатор категории</value>
        public int CategoryId { get; set; }
        /// <summary>
        /// Ссылка на категории
        /// </summary>
        /// <value>Категории</value>
        public ModelCategory Category { get; set; }
        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        /// <value>Идентификатор производителя</value>
        public int ManufacturerId { get; set; }
        /// <summary>
        /// Ссылка на производителей
        /// </summary>
        /// <value>Производители</value>
        public ModelManufacturer Manufacturer { get; set; }
    }
    /// <summary>
    /// Класс модели производителя
    /// </summary>
    public class ModelManufacturer
    {
        /// <summary>
        /// Идентификатор производителя
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Наименование производителя
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
    }
}
