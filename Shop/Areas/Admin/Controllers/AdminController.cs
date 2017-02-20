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

        public ActionResult Products()
        {
            
            return View();
        }

        public ActionResult Category()
        {

            return View();
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
        public ActionResult upProducts()
        {
            var products = Services.Product.ProductsPreview();
            return View(products);
        }
        public ActionResult upCategory()
        {
            var category = Services.Product.GetCategory();
            return View(category);
        }

        [HttpPost]
        public JsonResult AddUser(string userName, string email, string password, string role, string status)
        {
            var salt = MyExtensions.GetSalt();
            Services.Admin.AddUser(userName, email, password, salt);
            return Json("Запрос успешно выполнен");
        }
    }
}