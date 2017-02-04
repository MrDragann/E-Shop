using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Infrastructura
{
    public class FilterUser : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var role = Roles;
            var user = Users;
            var userName = WebUser.CurrentUser.UserName;
            bool u;
            using (var db = new DataContext())
            {
                var t = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                u = t.Any(x => x.UserName == WebUser.CurrentUser.UserName);
            }
                
            if (user == userName || u)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;
        
        }

        
    }
}