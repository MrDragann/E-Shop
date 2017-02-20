using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IServices.Models;
using System.Linq.Expressions;
using IServices.Models.User;

namespace IServices
{
    public class UserServices : IUserServices
    {
        public bool CheckRole(string userName, string role)
        {
            using (var db = new DataContext())
            {
                var users = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                bool included = users.Any(x => x.UserName == userName);
                return included;
            }
        }

        public bool Login(string userName, string password)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.UserName == userName);
                var HeshPass = (user.Salt + password).GetHashString();

                var authorized = db.Users.Any(_ => _.UserName == userName && _.Password == HeshPass && _.StatusUserId != EnumStatusUser.Locked );
                if (authorized)
                {
                    user.LastLoginDate = DateTime.Now;
                    db.SaveChanges();
                }
                return authorized;
            }
        }

        public ModelUser Login(int userId)
        {
            using (var db = new DataContext())
            {
              
                return db.Users.Select(SelectDetailUser()).FirstOrDefault(x => x.Id == userId);
                
            }
        }

        public void ResetPassword(string email, string password, string salt)
        {
            using(var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Email == email);
                user.Salt = salt;
                user.Password = (salt + password).GetHashString();
                db.SaveChanges();
            }
        }

        public static List<ModelRole> GetRoles()
        {
            using(var db = new DataContext())
            {
                var roles = db.Roles.Select(SelectDetailRole()).ToList();
                return roles;
            }
        }

        public static List<ModelStatus> GetStatuses()
        {
            using (var db = new DataContext())
            {
                var statuses = db.StatusUsers.Select(SelectDetailStatus()).ToList();
                return statuses;
            }
        }

        public static Expression<Func<User, ModelUser>> SelectDetailUser()
        {
            return user => new ModelUser()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = user.Roles.Select(role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name }).ToList()
            };
        }

        public static Expression<Func<Role, ModelRole>> SelectDetailRole()
        {
            return role => new ModelRole { Id = (ModelEnumTypeRoles)role.Id, Name = role.Name };
        }

        public static Expression<Func<StatusUser, ModelStatus>> SelectDetailStatus()
        {
            return status => new ModelStatus { Id = (ModelEnumStatusUser)status.Id, Name = status.Name };
        }
    }
}
