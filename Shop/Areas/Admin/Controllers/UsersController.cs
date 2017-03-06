using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        
        /// <summary>
        /// Страница с таблицей всех пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Удаляет выбраных пользователей из БД 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteUsers(string list)
        {
            var usersList = list.Split(',').Select(int.Parse).ToList();
            AdminServices.Users.DeleteUsers(usersList);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменяет статус пользователя на заблокированного
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BlockUsers(string list)
        {
            var usersList = list.Split(',').Select(int.Parse).ToList();
            AdminServices.Users.BLockUsers(usersList);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Назначение роли пользователю
        /// </summary>
        /// <param name="role">Выбранная роль</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditRole(int role, string list)
        {
            var usersList = list.Split(',').Select(int.Parse).ToList();
            AdminServices.Users.EditRole(usersList, role);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление таблицы пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxUsers()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Регистрирует нового пользователя и отправляет на указанную ип почту письмо с потверждением аккаунта
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUser(string userName, string email, string password)
        {
            var salt = WebUser.Register(userName, email, password);
            WebUser.SendMail("Подтвердите регистрацию", email,
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { area = "", salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
            return Json("Запрос успешно выполнен");
        }
    }
}