using IServices.Models;
using Shop.Infrastructura.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Страница управления товарами
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
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
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteProducts(string list)
        {
            var productList = list.Split(',').Select(int.Parse).ToList();
            AdminServices.Products.DeleteProducts(productList);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление товаров
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxProducts()
        {
            var products = Services.Product.ProductsDetails();



            return View(products);//("",products);
        }
        public ActionResult ManufacturersList()
        {
            var manufacturers = Services.Product.GetManufacturers();
            return View(manufacturers);
        }
        
        public ActionResult EditProduct(int id)
        {
            var products = Services.Product.ProductsDetails();
            var product = products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(ModelProduct model)
        {
            AdminServices.Products.EditProduct(model);
            return Json("Запрос успешно выполнен");
        }
    }
}