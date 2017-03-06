using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Infrastructura.Extensions;
using Shop.Infrastructura.Constants;
using Shop.Infrastructura;
using IServices.Models;
using System.IO;

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
        
    }
}