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
            
            bool included = false;
            if (role != "")
            {
                included = WebUser.CheckRole(WebUser.CurrentUser.Id, role);
            }
            if (user == WebUser.CurrentUser.UserName || included)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;
        
        }

        
    }
}