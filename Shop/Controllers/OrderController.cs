﻿using IServices.Models;
using Shop.Infrastructura;
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
            return View();
        }
        public ActionResult AjaxCart()
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
        /// <summary>
        /// Вывод всех имеющихсся заказов пользователя
        /// </summary>
        /// <returns></returns>
        [FilterUser(IsAuth = true)]
        public ActionResult MyOrders()
        {
            var orders = Services.Users.Orders(User.UserName);
            return View(orders);
        }
        /// <summary>
        /// Переход к оформлению заказа
        /// </summary>
        /// <returns></returns>
        [FilterUser(IsAuth = true)]
        [HttpPost]
        public ActionResult Checkout()
        {
            var ModelOrder = Services.Users.GoToCheckout(User.UserName);
            return View(ModelOrder);
        }
        /// <summary>
        /// Подтверждение оформления заказа
        /// </summary>
        /// <returns></returns>
        [FilterUser(IsAuth = true)]
        [HttpPost]
        public ActionResult ConfirmOrder()
        {
            Services.Users.ConfirmOrder(User.UserName);
            return RedirectToAction("MyOrders");
        }
        /// <summary>
        /// Подтверждение получения заказа
        /// </summary>
        /// <param name="OrderId">Идентификатор заказа</param>
        /// <returns></returns>
        [FilterUser(IsAuth = true)]
        [HttpPost]
        public ActionResult ConfirmReceipt(int OrderId)
        {
            Services.Users.ConfirmReceipt(User.UserName, OrderId);
            return RedirectToAction("MyOrders");
        }
        /// <summary>
        /// Отмена заказа
        /// </summary>
        /// <param name="OrderId">Идентификатор заказа</param>
        /// <returns></returns>
        [FilterUser(IsAuth = true)]
        [HttpPost]
        public ActionResult CancelOrder(int OrderId)
        {
            Services.Users.CancelOrder(User.UserName, OrderId);
            return RedirectToAction("MyOrders");
        }

    }
}