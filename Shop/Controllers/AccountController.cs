using DataModel;
using IServices.Models;
using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            WebUser.Login(userName, HashPass, RememberMe == "on");

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
        public ActionResult Register(string userName, string password1)
        {
            //Может пригодиться
            //using (var db = new DataContext())
            //{
            //    var user = db.Users.Include(_ => _.Roles).FirstOrDefault(_ => _.Id == 20);
            //    user.Roles = db.Roles.Where(_ => new[] { TypeRoles.User, TypeRoles.Moderator }.Contains(_.Id)).ToList();
            //    db.SaveChanges();

            //}
            string HashPass = Security.Instance.GetHashString(password1);
            string salt = Security.Instance.GetSalt();
            using (var db = new DataContext())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = salt + HashPass,
                    Salt = salt,
                    Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                };

                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("login");
        }
    }
}