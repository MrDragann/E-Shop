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
        public bool CheckRole(int id, string role)
        {
            using (var db = new DataContext())
            {
                var users = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                bool included = users.Any(x => x.Id == id);
                return included;
            }
        }

        public bool Login(string userName, string password)
        {
            using (var db = new DataContext())
            {
                var authorized = db.Users.Any(_ => _.UserName == userName && _.Password == _.Salt + password && _.StatusUserId != EnumStatusUser.Locked );
                if (authorized)
                {
                    var user = db.Users.Include(_ => _.Roles).FirstOrDefault(x => x.UserName == userName);
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
    }
}
