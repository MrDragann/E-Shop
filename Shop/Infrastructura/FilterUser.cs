using DataModel;
using System;
using System.Collections.Generic;
using ProductModel.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Infrastructura
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterUser : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            //base.OnAuthorization(filterContext);
            // Переадресация
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                { "controller", "Account" }, { "action", "Login" }
            });
            }

        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /// Извлечение имен и ролей пользователей, авторизованных
            /// для получения доступа
            var role = Roles;
            var user = Users;
            string[] _rolesSplit = Security.Instance.Split(role); 
            var cookie = httpContext.Request.Cookies["User"];
            string UserName; bool IsAuth = false;
            if (WebUser.CurrentUser.UserName == null && cookie != null) 
            {
                UserName = cookie.Values["UserName"];
                if (cookie.Values["IsAuth"] == "True") IsAuth = true;
            }
            else
            {
                UserName = WebUser.CurrentUser.UserName;
            }

            bool u = false;
            if (role != "")
            {
                /// Проверка соответствия роли пользователя
                using (var db = new DataContext())
                {
                    var t = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                    u = t.Any(x => x.UserName == UserName);
                }
            }
            if (user == UserName || u)
            {
                if (IsAuth) return true;
                else return WebUser.CurrentUser.IsAuth;
            }
            return false;
        
        }

        
    }
}