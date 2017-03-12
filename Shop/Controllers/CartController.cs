using IServices.Models;
using System.Web.Mvc;

namespace Shop.Controllers
{
    /// <summary>
    /// Содержит методы для работы с корзиной пользователя
    /// </summary>
    /// <seealso cref="Shop.Controllers.BaseController" />
    public class CartController : BaseController
    {
        /// <summary>
        /// Корзина пользователя
        /// </summary>
        /// <returns>Содержимое корзины</returns>
        public ViewResult Index()
        {
            return View(Services.Users.GetCart(User.UserName));
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="Quantity">Количество</param>
        /// <returns>RedirectToRouteResult.</returns>
        [HttpPost]
        public RedirectToRouteResult AddToCart(int productId, int Quantity)
        {
            Services.Users.AddToCart(productId, Quantity, User.UserName);

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Изменение количества товара
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <param name="Quantity">Количество</param>
        /// <returns>RedirectToRouteResult.</returns>
        [HttpPost]
        public ActionResult EditQuantity(int productId, int Quantity)
        {
            Services.Users.EditQuantity(productId, Quantity, User.UserName);

            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <returns>RedirectToRouteResult.</returns>
        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int productId)
        {
            Services.Users.DeleteItem(productId, User.UserName);

            return RedirectToAction("Index");
        }        

    }
}