using IServices;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Infrastructura
{
    public class WebUser
    {
        private static IMainServices Services = DependencyResolver.Current.GetService<IMainServices>();

        public static ModelUser CurrentUser
        {
            get
            {
                return HttpContext.Current.Session["user"] as ModelUser ?? new ModelUser();
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

        public static void Login(string userName, string password)
        {
            if (Services.Users.Login(userName, password))
            {
                CurrentUser = new ModelUser { UserName = userName, IsAuth = true };
            }
        }

        public static void LogOff()
        {
            HttpContext.Current.Session.Remove("user");
        }

    }
}