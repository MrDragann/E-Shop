using System.Collections.Generic;

namespace DataModel.Models
{
    /// <summary>
    /// Класс модели категорий
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Наименование категории
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        /// <value>Родитель</value>
        public Category Parent { get; set; }
        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        /// <value>Идентификатор</value>
        public int? ParentId { get; set; }
        /// <summary>
        /// Список дочерних категорий
        /// </summary>
        /// <value>Дочерняя</value>
        public List<Category> Сhild { get; set; }
        /// <summary>
        /// Ссылка на список товаров
        /// </summary>
        /// <value>Товары</value>
        public List<Product> Products { get; set; }
    }
    /// <summary>
    /// Класс модели производителя
    /// </summary>
    public class Manufacturer
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
        /// <summary>
        /// Ссылка на список товаров
        /// </summary>
        /// <value>Товары</value>
        public List<Product> Products { get; set; }
    }
}