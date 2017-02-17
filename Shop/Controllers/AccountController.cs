using IServices.Models;
using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Shop.Infrastructura.Extensions;

namespace Shop.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// Страница входа/регистрации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password, string RememberMe)
        {
            WebUser.Login(userName, password.GetHashString(), RememberMe == "on");

            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            WebUser.LogOff();

            return RedirectToAction("index","home");
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password1"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string userName, string email, string password1)
        {
            ////Может пригодиться
            //using (var db = new DataContext())
            //{
            //    var user = db.Users.Include(_ => _.Roles).FirstOrDefault(_ => _.Id == 19);
            //    user.Roles = db.Roles.Where(_ => new[] { TypeRoles.Admin }.Contains(_.Id)).ToList();
            //    db.SaveChanges();

            //}
            WebUser.Register(userName, email, password1);
            return RedirectToAction("login");
        }
        /// <summary>
        /// Корзина
        /// </summary>
        /// <returns></returns>
        public ActionResult Cart()
        {
            var products = Services.Product.ProductsPreview();
            return View(products.Take(2));
        }

    }
}