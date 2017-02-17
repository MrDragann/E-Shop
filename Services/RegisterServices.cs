using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public class RegisterServices : IRegisterServices
    {
        public bool Register(string userName, string email, string password, string salt)
        {
            try
            {
                using (var db = new DataContext())
                {
                    User user = new User()
                    {
                        UserName = userName,
                        Email = email,
                        Password = salt + password,
                        Salt = salt,
                        UserProfile = new UserProfile
                        {
                            RegistrationDate = DateTime.Now,
                            LastLoginDate = DateTime.Now,
                            ConfirmedEmail = false,
                            ConfirmationCode = "privetos " + userName
                        },
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
