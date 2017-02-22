using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IServices.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using IServices;
using IServices.Models.User;
using IServices.SubInterfac.Admin;

namespace Services
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
        public void DeleteUsers(List<int> id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    foreach (int item in id)
                    {
                        var user = db.Users.FirstOrDefault(_ => _.Id == item);
                        var profile = db.AccountConfirmations.FirstOrDefault(_ => _.UserId == item);
                        db.Users.Remove(user);
                        db.AccountConfirmations.Remove(profile);
                    }
                    db.SaveChanges();
                }
            }
            catch 
            {

            }
        }
        /// <summary>
        /// Блокировка выбраных пользователей
        /// </summary>
        /// <param name="id">Список пользователй</param>
        public void BLockUsers(List<int> id)
        {
            try
            {
                using (var db = new DataContext())
                {
                    foreach (int item in id)
                    {
                        var user = db.Users.FirstOrDefault(_ => _.Id == item);
                        user.StatusUserId = EnumStatusUser.Locked;
                    }
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
        public void EditRole(List<int> id, int roleId)
        {
            try
            {
                using (var db = new DataContext())
                {
                    foreach (int item in id)
                    {
                        var user = db.Users.Include(x => x.Roles).FirstOrDefault(_ => _.Id == item);
                        if (roleId == 0)
                        {

                            user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.Admin).ToList();

                        }
                        if (roleId == 1)
                        {

                            user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.Moderator).ToList();
                        }
                        if (roleId == 2)
                        {

                            user.Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList();
                        }

                    }
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
                Status = users.StatusUserId,
                Roles = users.Roles.Select(role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name }).ToList()

            };
        }
    }
}

    