using IServices.Models;
using Shop.Infrastructura;
using Shop.Infrastructura.Constants;
using System.Linq;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    /// <summary>
    /// Представляет методы осуществляющие действия над пользователями
    /// </summary>
    /// <seealso cref="Shop.Areas.Admin.Controllers.BaseController" />
    [FilterUser(Roles = "Администратор")]
    public class UsersController : BaseController
    {

        /// <summary>
        /// Страница с таблицей всех пользователей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Index()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Удаляет выбранного пользователя из БД
        /// </summary>
        /// <param name="userId">Идентификатор пользвателя</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            AdminServices.Users.DeleteUser(userId);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменяет статус пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользвателя</param>
        /// <param name="status">Новый статус</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult EditStatus(int userId, ModelEnumStatusUser status)
        {
            AdminServices.Users.EditStatus(userId, status);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Назначение роли пользователю
        /// </summary>
        /// <param name="userId">Идентификатор пользвателя</param>
        /// <param name="role">Выбранная роль</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult EditRole(int userId, ModelEnumTypeRoles role)
        {
            AdminServices.Users.EditRole(userId, role);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Частичное представление таблицы пользователей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxUsers()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Вывод имеющихся ролей пользователей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxRoles()
        {
            var roles = Services.Users.GetRoles();
            return View(roles);
        }
        /// <summary>
        /// Вывод имеющихся статусов пользователей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxStatuses()
        {
            var statuses = Services.Users.GetStatuses();
            return View(statuses);
        }
        /// <summary>
        /// Регистрирует нового пользователя и отправляет на указанную ип почту письмо с потверждением аккаунта
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>System.Web.Mvc.JsonResult.</returns>
        [HttpPost]
        public JsonResult AddUser(string userName, string email, string password)
        {
            var salt = WebUser.Register(userName, email, password);
            WebUser.SendMail("Подтвердите регистрацию", email,
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { area = "", salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
            return Json("Запрос успешно выполнен");
        }

        #region Заказы
        /// <summary>
        /// Страница с таблицей всех заказов
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Orders()
        {
            return View();
        }
        /// <summary>
        /// Частичное представление таблицы заказов
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxOrders(string UserName, int pageNum = 0)
        {
            var orders = AdminServices.Users.Orders(UserName);
            MyConstats.PageNum = pageNum;
            MyConstats.ItemsCount = orders.Count();
            int pageSize = 5;
            return View(orders.Skip(pageSize * pageNum).Take(pageSize));
        }
        public ActionResult AutocompleteUsersSearch(string term)
        {
            var users = AdminServices.Users.SearchUser(term);
            var models = users.Select(x => new { value = x.UserName }).ToList();
            return Json(models, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Вывод имеющихся статусов заказов
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxOrderStatuses()
        {
            var statuses = AdminServices.Users.GetOrderStatuses();
            return View(statuses);
        }
        /// <summary>
        /// Изменяет статус заказа
        /// </summary>
        /// <param name="OrderId">Идентификатор заказа</param>
        /// <param name="StatusId">Новый статус</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult EditOrderStatus(int OrderId, ModelEnumStatusOrder StatusId)
        {
            AdminServices.Users.EditOrderStatus(OrderId, StatusId);
            return Json("Запрос успешно выполнен");
        }
        #endregion
        /// <summary>
        /// Страница с таблицей всех пользователей
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Feedbacks()
        {
            var feedbacks = AdminServices.Users.ShowFeedbacks();
            return View(feedbacks);
        }
    }
}