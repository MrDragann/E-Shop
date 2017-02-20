using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;
using Shop.Infrastructura;

namespace Shop.Areas.Admin.Controllers
{
    [FilterUser(Roles = "Администратор")]
    public class AdminController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var users = Services.Admin.Users();
            return View(users);
        }


        [HttpPost]
        public ActionResult DeleteUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            Services.Admin.DeleteUsers(list);
            return Json("Запрос успешно выполнен");
        }

        [HttpPost]
        public ActionResult BlockUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            Services.Admin.BLockUsers(list);
            return Json("Запрос успешно выполнен");
        }
        public ActionResult upUsers()
        {
            var users = Services.Admin.Users();
            return View(users);
        }

        [HttpPost]
        public JsonResult AddUser(string userName, string email, string password)
        {
            var salt = MyExtensions.GetSalt();
            Services.Register.Register(userName, email, password, salt);
            WebUser.SendMail("Подтвердите регистрацию", email,
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { area = "", salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
            return Json("Запрос успешно выполнен");
        }
    }
}