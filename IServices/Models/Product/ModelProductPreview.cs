using System;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели товара с частичной информацией
    /// </summary>
    public class ModelProductPreview
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
        /// Цена товара
        /// </summary>
        /// <value>Цена</value>
        public int Price { get; set; }
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


    }
}
