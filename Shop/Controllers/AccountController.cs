using DataModel;
using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            WebUser.Login(userName, password);
            return RedirectToAction("index", "home");
        }
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            return RedirectToAction("index","home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string password1, string password2)
        {
            using (var db = new DataContext())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = password1
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
                return RedirectToAction("index", "home");
        }
    }
}