using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IServices.Models;
using System.Threading.Tasks;
using DataModel;
using System.Linq.Expressions;
using IServices;

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

        public void BLockUsers(List<int> id)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var user = db.Users.FirstOrDefault(_ => _.Id == item);
                    user.Status = "Заблокирован";
                }
                db.SaveChanges();
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
                Status = users.Status
                
            };
        }
    }
}

    