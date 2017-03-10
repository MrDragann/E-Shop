using IServices.Models;

/// <summary>
/// Содержит интерфейсы публичной и административной части приложения
/// </summary>
namespace IServices.SubInterface
{
    /// <summary>
    /// Определяет методы связанные с товарами
    /// </summary>
    public interface IAdminProductServices
    {
        #region Товары
        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="product">Товар</param>
        void AddProduct(ModelProduct product);
        /// <summary>
        /// Удаление выбранных товаров
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        void DeleteProducts(int id);
        /// <summary>
        /// Редактирование выбранного товара
        /// </summary>
        /// <param name="model">Модель товара</param>
        void EditProduct(ModelProduct model);
        #endregion

        #region Категории
        /// <summary>
        /// Добавление главной категории
        /// </summary>
        /// <param name="name">Название категории</param>
        void AddMainCategory(string name);
        /// <summary>
        /// Добавление дочерней категории
        /// </summary>
        /// <param name="mainId">Идентификатор главной категории</param>
        /// <param name="child">Название дочерней категории</param>
        void AddChildCategory(int mainId, string child);
        /// <summary>
        /// Изменение названия главной категории
        /// </summary>
        /// <param name="mainId">Идентификатор главной категории</param>
        /// <param name="newName">Новое название</param>
        void EditMainCategory(int mainId, string newName);
        /// <summary>
        /// Изменение названия дочерней категории
        /// </summary>
        /// <param name="childId">Идентификатор дочерней категории</param>
        /// <param name="newName">Новое название</param>
        void EditChildCategory(int childId, string newName);
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="mainId">Идентификатор родительской категории</param>
        void DeleteMainCategory(int mainId);
        /// <summary>
        /// Удаление дочерней категории
        /// </summary>
        /// <param name="childId">Идентификатор дочерней категории</param>
        void DeleteChildCategory(int childId);
        #endregion
    }
}
