﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;
using Shop.Infrastructura;

namespace Shop.Areas.Admin.Controllers
{
    //[FilterUser(Roles = "Администратор")]
    public class AdminController : BaseController
    {
        // GET: Admin/Home
        /// <summary>
        /// Главная страница админки
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Страница с таблицей всех пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult Users()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }

        public ActionResult Products()
        {
            
            return View();
        }
        /// <summary>
        /// Страница управления категориями
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {
            return View();
        }
        /// <summary>
        /// Удаляет выбраных пользователей из БД 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.DeleteUsers(list);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменяет статус пользователя на заблокированного
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BlockUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.BLockUsers(list);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Назначение роли пользователю
        /// </summary>
        /// <param name="role">Выбранная роль</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditRole()
        {
            var roleId = Convert.ToInt32(Request.Form["role"]);
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.EditRole(list, roleId);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление таблицы пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult upUsers()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Добавление главной категории
        /// </summary>
        /// <param name="name">Название новой категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMainCategory(string name)
        {
            AdminServices.Categories.AddMainCategory(name);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Добавление дочерней категории
        /// </summary>
        /// <param name="mainId">Id главной категории</param>
        /// <param name="child">Название новой категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddChildCategory(string mainId, string child)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Categories.AddChildCategory(id, child);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменение названия главной категории
        /// </summary>
        /// <param name="mainId">Id главной категории</param>
        /// <param name="newName">Новое название</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditMainCategory(string mainId, string newName)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Categories.EditMainCategory(id, newName);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменение названия дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <param name="newName">Новое название</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditChildCategory(string childId, string newName)
        {
            var id = Convert.ToInt32(childId);
            AdminServices.Categories.EditChildCategory(id, newName);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="mainId">Id родительской категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteMainCategory(string mainId)
        {
            var id = Convert.ToInt32(mainId);
            AdminServices.Categories.DeleteMainCategory(id);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление дочерней категории
        /// </summary>
        /// <param name="childId">Id дочерней категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteChildCategory(string childId)
        {
            var id = Convert.ToInt32(childId);
            AdminServices.Categories.DeleteChildCategory(id);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление категорий
        /// </summary>
        /// <returns></returns>
        public ActionResult upCategories()
        {
            return View();
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