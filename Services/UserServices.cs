using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        public bool Login(string userName, string password)
        {
            using (var db = new DataContext())
            {
                return db.Users.Any(_ => _.UserName == userName && _.Password == password);
            }
        }
    }
}
