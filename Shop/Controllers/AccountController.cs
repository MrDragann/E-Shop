using DataModel;
using IServices.Models;
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
        public ActionResult Login(string userName, string password, string RememberMe)
        {
            string HashPass = Security.Instance.GetHashString(password);
            WebUser.Login(userName, HashPass);

            var user = WebUser.CurrentUser;
            if (user.IsAuth == true)
            {
                //Session["user"] = user;
                 
                if (RememberMe=="on") //Request.Cookies["User"] == null)
                {
                    HttpCookie cookie = new HttpCookie("User");
                    cookie["UserName"] = user.UserName;
                    cookie["IsAuth"] = WebUser.CurrentUser.IsAuth.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
            }

            return RedirectToAction("index", "home");
        }
        public ActionResult LogOut()
        {
            WebUser.LogOff();

            if (Request.Cookies["User"] != null)
            {
                HttpCookie myCookie = new HttpCookie("User");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index","home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string password1)
        {
            string HashPass = Security.Instance.GetHashString(password1);
            string salt = Security.Instance.GetSalt();
            using (var db = new DataContext())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = salt + HashPass,
                    Salt = salt
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
                return RedirectToAction("login");
        }
    }
}