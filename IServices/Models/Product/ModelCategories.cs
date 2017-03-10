using System.Collections.Generic;
using System.Linq;

namespace IServices.Models
{
    /// <summary>
    /// Класс для работы с моделью категорий
    /// </summary>
    public class ModelCategories
    {
        /// <summary>
        /// Список категорий
        /// </summary>
        /// <value>Категории</value>
        public List<ModelCategory> Categories { get; set; }

        /// <summary>
        /// Вывод списка родительских категорий
        /// </summary>
        /// <returns>List&lt;ModelCategory&gt;.</returns>
        public List<ModelCategory> GetParents() { return Categories.Where(_ => !_.ParentId.HasValue).ToList(); }

        /// <summary>
        /// Вывод родительской категории
        /// </summary>
        /// <param name="parentId">Идентификатор родительской категории</param>
        /// <returns>ModelCategory.</returns>
        public ModelCategory GetParent(int? parentId) { return Categories.FirstOrDefault(_ => _.Id == parentId); }

        /// <summary>
        /// Вывод списка дочерних категорий
        /// </summary>
        /// <param name="parentId">Идентификатор родительской категории</param>
        /// <returns>List&lt;ModelCategory&gt;.</returns>
        public List<ModelCategory> GetChild(int? parentId) { return Categories.Where(_ => _.ParentId == parentId).ToList(); }
    }
}
