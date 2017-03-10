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
    /// <summary>
    /// Представляет методы осуществляющие действия над аккаунтом
    /// </summary>
    /// <seealso cref="Shop.Controllers.BaseController" />
    public class AccountController : BaseController
    {
        /// <summary>
        /// Страница входа/регистрации
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="RememberMe">Функция запомнить</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Login(string userName, string password, string RememberMe)
        {
            WebUser.Login(userName, password, RememberMe == "on");

            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult LogOut()
        {
            WebUser.LogOff();

            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="email">Эл.адрес</param>
        /// <param name="password1">Пароль</param>
        /// <returns>System.Web.Mvc.ActionResult.</returns>
        [HttpPost]
        public ActionResult Register(string userName, string email, string password1)
        {
            // Отправка письма с подтверждением аккаунта
            var salt = WebUser.Register(userName, email, password1);
            WebUser.SendMail("Подтвердите регистрацию", email,
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");

            return RedirectToAction("login");
        }
        /// <summary>
        /// Подтверждение аккаунта
        /// </summary>
        /// <param name="salt">Соль</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns>System.Web.Mvc.ActionResult.</returns>
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
        /// Сброс пароля пользователя
        /// </summary>
        /// <param name="email">Эл. адрес</param>
        /// <returns>System.Web.Mvc.ActionResult.</returns>
        [HttpPost]
        public ActionResult ResetPassword(string email)
        {
            // Отправка письма с ссылкой на сброс пароля
            WebUser.SendMail("Востоновления пароля", email,
                $@"Для восстановления  пароля перейдите по 
                 <a href='{Url.Action("NewPassword", "Account", new { email = email }, Request.Url.Scheme)}'
                 title='Востоновления пароля'>ссылке</a>");
            return RedirectToAction("login");
        }
        /// <summary>
        /// Страниица с вводом нового пароля
        /// </summary>
        /// <returns>System.Web.Mvc.ActionResult.</returns>
        public ActionResult NewPassword()
        {
            return View();
        }
        /// <summary>
        /// Установка нового пароля
        /// </summary>
        /// <param name="email">Эл.адрес</param>
        /// <param name="password1">Пароль</param>
        /// <returns>System.Web.Mvc.ActionResult.</returns>
        [HttpPost]
        public ActionResult NewPassword(string email, string password1)
        {
            WebUser.NewPassword(email, password1);
            return RedirectToAction("Login");
        }



    }
}