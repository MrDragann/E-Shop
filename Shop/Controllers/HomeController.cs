using Shop.Infrastructura;
using IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Shop.Infrastructura.Constants;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;
using Services;

/// <summary>
/// Контроллеры публичной части приложения
/// </summary>
namespace Shop.Controllers
{

    /// <summary>
    /// Контроллер главной части приложения
    /// </summary>
    /// <seealso cref="Shop.Controllers.BaseController" />
    public class HomeController : BaseController
    {

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод последних добавленных товаров</returns>
        public ActionResult Index()
        {
            var products = Services.Product.ProductsPreview();
            return View(products.OrderByDescending(x => x.DateAdd).Take(6));
        }

        /// <summary>
        /// Поиск товаров по категории
        /// </summary>
        /// <param name="Category">Название категории</param>
        /// <param name="pageNum">Номер страницы</param>
        /// <param name="sort">Параметр соритровки</param>
        /// <returns>Список товаров</returns>
        public ActionResult Category(int Category, int pageNum = 0, TypeSort sort = TypeSort.NameAsc)
        {
            ViewBag.Message = Services.Product.GetCategoryName(Category);
            var products = Services.Product.ProductsPreview().Where(x => x.CategoryId == Category);
            MyConstats.PageNum = pageNum;
            MyConstats.ItemsCount = products.Count();
            int pageSize = MyConstats.PageSize;
            switch (sort)
            {
                case TypeSort.NameAsc: products = products.OrderBy(x => x.Name); break;
                case TypeSort.NameDesc: products = products.OrderByDescending(x => x.Name); break;
                case TypeSort.PriceAsc: products = products.OrderBy(x => x.Price); break;
                case TypeSort.PriceDesc: products = products.OrderByDescending(x => x.Price); break;
            }
            return View(products.Skip(pageSize * pageNum).Take(pageSize));
        }
        /// <summary>
        /// Информация о товаре
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns>Вывод информации о товаре</returns>
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var product = Services.Product.GetProduct((int)id);
            if (product != null)
            {
                return View(product);
            }
            return View("Error");
        }

        /// <summary>
        /// Страница с контактами
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// Страница с ошибкой
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// Вывод дерева категорий
        /// </summary>
        /// <returns>Дерево категорий</returns>
        public ActionResult Categories()
        {
            var model = Services.Product.GetCategory();
            return View(model);
        }
        /// <summary>
        /// Вывод товаров для слайдера
        /// </summary>
        /// <returns>List&lt;ModelProduct&gt;.</returns>
        public ActionResult Slider()
        {
            var slider = Services.Product.Slider();
            return View(slider);
        }

    }
}