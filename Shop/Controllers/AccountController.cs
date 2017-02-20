using IServices.Models;
using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Shop.Infrastructura.Extensions;
using System.Net.Mail;

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
            WebUser.Login(userName, password, RememberMe == "on");

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

            var salt = WebUser.Register(userName, email, password1);
            WebUser.SendMail("Подтвердите регистрацию", email, 
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
            

            return RedirectToAction("login");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ActionResult Confrimed(string salt, string userName)
        {
            if (salt != null)
            {
                WebUser.Confrimed(salt, userName);
                return RedirectToAction("index", "home");
            }
            return View("Error");
        }
        
        [HttpPost]
        public ActionResult ResetPassword(string email)
        {
            WebUser.SendMail("Востоновления пароля", email,
                $@"Для восстановления  пароля перейдите по 
                 <a href='{Url.Action("NewPassword", "Account", new { email = email }, Request.Url.Scheme)}'
                 title='Востоновления пароля'>ссылке</a>");
            return RedirectToAction("login");
        }

        public ActionResult NewPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPassword(string email, string password1)
        {
            WebUser.NewPassword(email, password1);
            return RedirectToAction("Login");
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