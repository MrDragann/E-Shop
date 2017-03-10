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

            return View(products);//("",products);
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
    }
}