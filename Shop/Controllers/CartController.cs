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
        /// <returns>RedirectToRouteResult.</returns>
        public RedirectToRouteResult AddToCart(int productId)
        {
            var product = Services.Product.GetProduct(productId);

            Services.Users.AddToCart(productId, 1, User.UserName);

            return RedirectToAction("Index");
        }
        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="productId">Идентификатор товара</param>
        /// <returns>RedirectToRouteResult.</returns>
        public RedirectToRouteResult RemoveFromCart(int productId)
        {
            var product = Services.Product.GetProduct(productId);

            Services.Users.DeleteItem(productId, User.UserName);

            return RedirectToAction("Index");
        }        

    }
}