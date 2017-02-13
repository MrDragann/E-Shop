using DataModel;
using IServices;
using Shop.Infrastructura.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public class RegisterServices : IRegisterServices
    {
        public bool Register(string userName, string password)
        {
            try
            {
                string salt = Security.Instance.GetSalt();
                using (var db = new DataContext())
                {
                    User user = new User()
                    {
                        UserName = userName,
                        Password = salt + password.GetHashString(),
                        Salt = salt,
                        Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                    };

                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
