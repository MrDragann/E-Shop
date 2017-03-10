using IServices;
using IServices.Models;
using Shop.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    /// <summary>
    /// Базовый контроллер с внедрением зависимости.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseController : Controller
    {
        public IMainServices Services { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="BaseController"/>.
        /// </summary>
        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
            User = WebUser.CurrentUser;
        }

        /// <summary>
        /// Получает сведения о безопасности пользователя для текущего HTTP-запроса.
        /// </summary>
        /// <value>Пользователь</value>
        public new ModelUser User { get; set; }
    }
}