using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Страница управления категориями
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Добавление главной категории
        /// </summary>
        /// <param name="name">Название новой категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMainCategory(string name)
        {
            AdminServices.Products.AddMainCategory(name);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Добавление дочерней категории
        /// </summary>
        /// <param name="mainId">Id главной категории</param>
        /// <param name="child">Название новой категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddChildCategory(string mainId, string child)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Products.AddChildCategory(id, child);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменение названия главной категории
        /// </summary>
        /// <param name="mainId">Id главной категории</param>
        /// <param name="newName">Новое название</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditMainCategory(string mainId, string newName)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Products.EditMainCategory(id, newName);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменение названия дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <param name="newName">Новое название</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditChildCategory(string childId, string newName)
        {
            var id = Convert.ToInt32(childId);
            AdminServices.Products.EditChildCategory(id, newName);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="mainId">Id родительской категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteMainCategory(string mainId)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Products.DeleteMainCategory(id);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteChildCategory(string childId)
        {
            var id = Convert.ToInt32(childId);
            AdminServices.Products.DeleteChildCategory(id);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление категорий
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxCategories()
        {
            var categories = Services.Product.GetCategory();
            return View(categories);
        }
        public ActionResult CategoriesList()
        {
            var categories = Services.Product.GetCategory();
            return View(categories);
        }
    }
}