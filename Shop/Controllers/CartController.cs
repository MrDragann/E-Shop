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
            return View(cart);
        }

        public RedirectToRouteResult AddToCart(ModelCart cart, int productId)
        {
            var product = Services.Product.GetProduct(productId);

            if (User.IsAuth)
            {
                Services.Users.AddItem(productId, 1, User.UserName);
            }
            else
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(ModelCart cart, int productId)
        {
            var product = Services.Product.GetProduct(productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult Summary(ModelCart cart)
        {
            return PartialView(cart);
        }
        

    }
}