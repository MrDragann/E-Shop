using IServices.Models;
using Shop.Infrastructura;
using Shop.Infrastructura.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    /// <summary>
    /// Представляет методы осуществляющие действия над товарами
    /// </summary>
    /// <seealso cref="Shop.Areas.Admin.Controllers.BaseController" />
    [FilterUser(Roles = "Администратор")]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Страница управления товарами
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="model">Модель товара</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult AddProduct(ModelProduct model)
        {
            if (model.file != null)
            {
                // получаем имя файла
                var fileName = model.file.FileName;
                var path = Server.MapPath(MyConstats.PathToProducts);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                model.FileName = fileName;
                // сохраняем файл в папку Images в проекте
                model.file.SaveAs(path + fileName);
            }
            else
            {
                model.FileName = "unknownProduct.jpg";
            }
            AdminServices.Products.AddProduct(model);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаляет выбранные товары из БД
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult DeleteProducts(int productId)
        {
            AdminServices.Products.DeleteProducts(productId);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление товаров
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxProducts()
        {
            var products = Services.Product.ProductsDetails();

            return View(products);
        }
        /// <summary>
        /// Вывод списка производителей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ManufacturersList()
        {
            var manufacturers = Services.Product.GetManufacturers();
            return View(manufacturers);
        }

        /// <summary>
        /// Вывод модели товара для редактирования
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns>ActionResult.</returns>
        public ActionResult EditProduct(int id)
        {
            var products = Services.Product.ProductsDetails();
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        /// <summary>
        /// Редактирование товара
        /// </summary>
        /// <param name="model">Новая модель товара</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult EditProduct(ModelProduct model)
        {
            AdminServices.Products.EditProduct(model);
            return Json("Запрос успешно выполнен");
        }

        #region Категории
        /// <summary>
        /// Страница управления категориями
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
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
        #endregion
    }
}