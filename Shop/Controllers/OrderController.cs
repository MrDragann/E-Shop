using IServices.Models;
using System.Web.Mvc;

namespace Shop.Controllers
{
    /// <summary>
    /// Содержит методы для работы с заказами пользователя
    /// </summary>
    /// <seealso cref="Shop.Controllers.BaseController" />
    public class OrderController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Корзина пользователя
        /// </summary>
        /// <returns>Содержимое корзины</returns>
        public ViewResult Cart()
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
        public ActionResult RemoveFromCart(int productId)
        {
            Services.Users.DeleteItem(productId, User.UserName);

            return Json("Запрос успешно выполнен");
        }        

        public ActionResult MyOrders()
        {
            var orders = Services.Users.Orders(User.UserName);
            return View(orders);
        }
        //[HttpPost]
        //public ActionResult NewOrder()
        //{
        //    var ModelOrder = Services.Users.NewOrder(User.UserName);
        //    return RedirectToAction("Checkout", ModelOrder);
        //}
        [HttpPost]
        public ActionResult Checkout(int? OrderId)
        {
            if (OrderId != null) 
            {

            }
            else
            {
                var ModelOrder = Services.Users.NewOrder(User.UserName);
                //var user = Services.Users.GoToCheckout(User.UserName);
                return View(ModelOrder);
            }
        }

    }
}