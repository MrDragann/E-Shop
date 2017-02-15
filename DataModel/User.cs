using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        // Ссылка на профиль
        public UserProfile UserProfile { get; set; }

        public List<Role> Roles { get; set; }
    }
}