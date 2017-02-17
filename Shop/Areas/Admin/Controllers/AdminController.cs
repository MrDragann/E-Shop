using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;

namespace Shop.Areas.Admin.Controllers
{
    public class AdminController : Shop.Controllers.BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var users = Services.Admin.Users();
            return View(users);
        }

        [HttpPost]
        public ActionResult Delete()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            Services.Admin.DeleteUsers(list);
            return Json("Загрузка завершена");
        }
    }
}