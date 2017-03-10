using System.Collections.Generic;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели категорий
    /// </summary>
    public class ModelCategory
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
        public ModelCategory Parent { get; set; }
        /// <summary>
        /// Идентификатор родительской категории
        /// </summary>
        /// <value>Идентификатор</value>
        public int? ParentId { get; set; }
        /// <summary>
        /// Список дочерних категорий
        /// </summary>
        /// <value>Дочерняя</value>
        public List<ModelCategory> Child { get; set; }
    }
}
