using DataModel;
using IServices.Models;
using IServices.Models.Product;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : BaseController
    {
        /// <summary>
        /// Корзина пользователя
        /// </summary>
        /// <returns></returns>
        public ViewResult Index(ModelCart cart)
        {
            if (User.IsAuth)
            {
                return View(Services.Users.GetCart(User.UserName));
            }
            else
            {
                return View(cart);
            }
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="quantity">Количество</param>
        public RedirectToRouteResult AddToCart(ModelCart cart, int productId)
        {
            var product = Services.Product.GetProduct(productId);

            if (User.IsAuth)
            {
                Services.Users.AddToCart(productId, 1, User.UserName);
            }
            else
            {
                cart.AddToCart(product, 1);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// /// <param name="cart"></param>
        /// <param name="productId"></param>
        public RedirectToRouteResult RemoveFromCart(ModelCart cart, int productId)
        {
            var product = Services.Product.GetProduct(productId);
            if (User.IsAuth)
            {
                //Services.Users.RemoveLine(productId, User.UserName);
            }
            else
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index");
        }

        //public PartialViewResult Summary(ModelCart cart)
        //{
        //    return PartialView(cart);
        //}
        

    }
}