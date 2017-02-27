using Shop.Infrastructura;
using IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;
using Services;

namespace Shop.Controllers
{
    
    public class HomeController : BaseController
    {
        
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var products = Services.Product.ProductsPreview();
            return View(products.Take(6));
        }
        
        /// <summary>
        /// Поиск товаров по категории
        /// </summary>
        /// <param name = "Category" > Название категории</param>
        /// <returns>Список товаров</returns>
        public ActionResult Category(int Category, TypeSort sort = TypeSort.NameAsc)
        {
            ViewBag.Message = Category;
            var products = Services.Product.ProductsPreview().Where(x => x.CategoryId == Category);
            switch (sort)
            {
                case TypeSort.NameAsc: products = products.OrderBy(x => x.Name); break;
                case TypeSort.NameDesc: products = products.OrderByDescending(x => x.Name); break;
                case TypeSort.PriceAsc: products = products.OrderBy(x => x.Price); break;
                case TypeSort.PriceDesc: products = products.OrderByDescending(x => x.Price); break;
            }
            return View(products);
        }
        /// <summary>
        /// Информация о товаре
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var products = Services.Product.ProductsDetails();
            var product = products.FirstOrDefault(x=>x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return View("Error");
        }
        
        /// <summary>
        /// Страница с контактами
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// Страница с ошибкой
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// Вывод дерева категорий
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {
            var model = Services.Product.GetCategory();
            return View(model);
        }

        

    }
}