using System.Web;
using System.Web.Mvc;

namespace Shop.Infrastructura
{
    /// <summary>
    /// Проверка доступа авторизованного пользователя 
    /// </summary>
    public class FilterUser : AuthorizeAttribute
    {
        /// <summary>
        /// Вызывается, когда процесс запрашивает авторизацию.
        /// </summary>
        /// <param name="filterContext">Контекст фильтра, инкапсулирующий сведения для использования объекта <see cref="T:System.Web.Mvc.AuthorizeAttribute" />.</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Переадресация
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary {
                    { "area", "" }, { "controller", "Account" }, { "action", "Login" }
            });
            }

        }

        /// <summary>
        /// В случае переопределения предоставляет точку входа для пользовательской проверки авторизации.
        /// </summary>
        /// <param name="httpContext">Контекст HTTP, который инкапсулирует все НТТР-данные об индивидуальном НТТР-запросе.</param>
        /// <returns>Значение true, если пользователь авторизован. В противном случае — значение false.</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /// Извлечение имен и ролей пользователей, авторизованных
            /// для получения доступа
            var role = Roles;
            var user = Users;
            
            bool included = false;
            if (role != "")
            {
                included = WebUser.CheckRole(WebUser.CurrentUser.UserName, role);
            }
            if (user == WebUser.CurrentUser.UserName || included)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;
        
        }

        
    }
}