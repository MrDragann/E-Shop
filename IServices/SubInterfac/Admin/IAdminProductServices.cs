using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.SubInterfac.Admin
{
    public interface IAdminProductServices
    {
        #region Товары
        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="product"></param>
        void AddProduct(ModelProduct product);
        /// <summary>
        /// Удаление выбранных товаров
        /// </summary>
        /// <param name="id"></param>
        void DeleteProducts(List<int> id);
        /// <summary>
        /// Редактирование выбранного товара
        /// </summary>
        /// <param name="model"></param>
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
        /// <param name="name">Название категории</param>
        void AddChildCategory(int mainId, string child);
        /// <summary>
        /// Изменение названия главной категории
        /// </summary>
        /// <param name="mainId">ID категории</param>
        /// <param name="newName">Новое название</param>
        void EditMainCategory(int mainId, string newName);
        /// <summary>
        /// Изменение названия дочерней категории
        /// </summary>
        /// <param name="childId">ID категории</param>
        /// <param name="newName">Новое название</param>
        void EditChildCategory(int childId, string newName);
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="mainId">Id родительской категории</param>
        /// <returns></returns>
        void DeleteMainCategory(int mainId);
        /// <summary>
        /// Удаление дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <returns></returns>
        void DeleteChildCategory(int childId);
        #endregion
    }
}
