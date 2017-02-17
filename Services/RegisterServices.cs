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
                        RegistrationDate = DateTime.Now,
                        LastLoginDate = DateTime.MinValue,
                        Status = "Не подтвержден",
                        AccountConfirmation = new AccountConfirmation
                        {
                            ConfirmedEmail = false,
                            ConfirmationCode = salt
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

        public bool ConfrimedEmail(string salt, string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.UserName == userName);
                var confirm = db.AccountConfirmations.FirstOrDefault(x => x.UserId == user.Id);
                if (db.AccountConfirmations.Any(x => x.ConfirmationCode == salt))
                {
                    user.Status = "Подтвержден";
                    confirm.ConfirmedEmail = true;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
    }
}
