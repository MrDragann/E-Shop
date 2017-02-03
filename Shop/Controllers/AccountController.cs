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
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            return RedirectToAction("index","home");
        }
    }
}