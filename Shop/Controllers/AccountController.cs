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

            var salt = WebUser.Register(userName, email, password1);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("testshop2018@gmail.com");
            msg.To.Add(email);
            msg.Subject = "Подтвердите регистрацию";
            msg.Body = string.Format("Для завершения регистрации перейдите по " +
                        "<a href=\"{0}\" title=\"Подтвердить регистрацию\">ссылке</a>",
            Url.Action("Confrimed", "Account", new { salt = salt, userName = userName }, Request.Url.Scheme));
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);

            return RedirectToAction("login");
        }

        public ActionResult Confrimed(string salt, string userName)
        {
            if (salt != null)
            {
                WebUser.Confrimed(salt, userName);
                return RedirectToAction("index", "home");
            }
            return View("Error");
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