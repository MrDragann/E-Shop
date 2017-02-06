using DataModel;
using IServices;
using ProductModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RegisterServices : IRegisterServices
    {
        public bool Register(string userName, string password)
        {
            try
            {
                string HashPass = Security.Instance.GetHashString(password);
                string salt = Security.Instance.GetSalt();
                using (var db = new DataContext())
                {
                    User user = new User()
                    {
                        UserName = userName,
                        Password = salt + HashPass,
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
