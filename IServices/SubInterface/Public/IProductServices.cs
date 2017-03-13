using IServices.Models;
using System.Collections.Generic;

namespace IServices.SubInterface
{
    /// <summary>
    /// Определяет методы связанные с товарами
    /// </summary>
    public interface IProductServices
    {
        /// <summary>
        /// Вывод частичной информации о товарах
        /// </summary>
        /// <returns>List&lt;ModelProductPreview&gt;.</returns>
        List<ModelProductPreview> ProductsPreview();
        /// <summary>
        /// Вывод полной информации о товарах
        /// </summary>
        /// <returns>List&lt;ModelProduct&gt;.</returns>
        List<ModelProduct> ProductsDetails();
        /// <summary>
        /// Вывод названия категории по ее идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>System.String.</returns>
        string GetCategoryName(int id);
        /// <summary>
        /// Вывод списка категорий
        /// </summary>
        /// <returns>ModelCategories.</returns>
        ModelCategories GetCategory();
        /// <summary>
        /// Вывод списка производителей
        /// </summary>
        /// <returns>List&lt;ModelManufacturer&gt;.</returns>
        List<ModelManufacturer> GetManufacturers();

        /// <summary>
        /// Вывод товара по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>ModelProduct.</returns>
        ModelProduct GetProduct(int id);

        /// <summary>
        /// Вывод товаров для слайдера
        /// </summary>
        /// <returns>List&lt;ModelProduct&gt;.</returns>
        List<ModelProduct> Slider();
    }
}
