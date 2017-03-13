using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DataModel;
using System.Linq.Expressions;
using IServices.Models;
using DataModel.Models;
using IServices.SubInterface;

namespace Services.Admin
{
    public class AdminUsersServices : IAdminUsersServices
    {
        /// <summary>
        /// Вывод всех пользовотелей 
        /// </summary>
        /// <returns></returns>
        public List<ModelUserInfo> Users()
        {
            using (var db = new DataContext())
            {
                var users = db.Users.Select(ShowUsers()).ToList();
                return users;
            }
        }
        /// <summary>
        /// Удаление выбраных пользователей
        /// </summary>
        /// <param name="id">Список пользователй</param>
        public void DeleteUser(int id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == id);
                    var profile = db.AccountConfirmations.FirstOrDefault(_ => _.UserId == id);
                    db.Users.Remove(user);
                    db.AccountConfirmations.Remove(profile);

                    db.SaveChanges();
                }
            }
            catch 
            {

            }
        }
        /// <summary>
        /// Изменение статуса пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="statusId">Выбранный статус</param>
        public void EditStatus(int userId, ModelEnumStatusUser statusId)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == userId);
                    user.StatusUserId = (EnumStatusUser)statusId;

                    db.SaveChanges();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Добавляет роль пользователю 
        /// </summary>
        /// <param name="id">Список пользователй</param>
        /// <param name="roleId">Выбранная роль</param>
        public void EditRole(int userId, ModelEnumTypeRoles roleId)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var user = db.Users.Include(x => x.Roles).FirstOrDefault(_ => _.Id == userId);
                    user.Roles = db.Roles.Where(_ => _.Id == (TypeRoles)roleId).ToList();

                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public static Expression<Func<User, ModelUserInfo>> ShowUsers()
        {
            return users => new ModelUserInfo()
            {
                Id = users.Id,
                UserName = users.UserName,
                Email = users.Email,
                RegistrationDate = users.RegistrationDate,
                LastLoginDate = users.LastLoginDate,
                Status = (ModelEnumStatusUser)users.StatusUserId,
                Roles = users.Roles.Select(role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name }).ToList()

            };
        }
        #region Заказы
        /// <summary>
        /// Вывод всех заказов
        /// </summary>
        /// <returns>List&lt;ModelOrder&gt;.</returns>
        public List<ModelOrder> Orders()
        {
            using (var db = new DataContext())
            {
                var order = db.Orders.Include(x => x.OrderProduct).Select(ShowOrders()).ToList();
                return order;
            }
        }

        public static Expression<Func<Order, ModelOrder>> ShowOrders()
        {
            return orders => new ModelOrder()
            {
                Id = orders.Id,
                UserId = orders.UserId,
                CreateDate = orders.CreateDate,
                StatusOrderId = (ModelEnumStatusOrder)orders.StatusOrderId

            };
        }
        #endregion
    }
}

    