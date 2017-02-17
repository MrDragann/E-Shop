using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;

namespace Shop.Areas.Admin.Controllers
{
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
    }
}