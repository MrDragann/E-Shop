﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IServices.Models;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using IServices;
using IServices.Models.User;

namespace Services
{
    public class AdminServices : IAdminServices
    {
        public List<UserInfo> Users()
        {
            using (var db = new DataContext())
            {
                var users = db.Users.Select(ShowUsers()).ToList();
                return users;
            }
        }

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

        public static Expression<Func<User, UserInfo>> ShowUsers()
        {
            return users => new UserInfo()
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

    