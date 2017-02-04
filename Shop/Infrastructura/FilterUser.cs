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
            //var r = Roles;
            var user = Users;
            if (user == WebUser.CurrentUser.UserName)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;
        
        }

        
    }
}