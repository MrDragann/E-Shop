using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var authorized = db.Users.Any(_ => _.UserName == userName && _.Password == _.Salt + password && _.Status != "Заблокирован");
                if (authorized)
                {
                    var user = db.Users.FirstOrDefault(x => x.UserName == userName);
                    user.LastLoginDate = DateTime.Now;
                    db.SaveChanges();
                }
                return authorized;
            }
        }


    }
}
