using System;
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

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public EnumStatusUser Status { get; set; }

        // Ссылка на профиль
        public AccountConfirmation AccountConfirmation { get; set; }

        public List<Role> Roles { get; set; }
    }

    public enum EnumStatusUser
    {
        Error,
        Status2,
        Status3
    }

    public class StatusUser
    {
        public EnumStatusUser Id { get; set; }

        public string Name { get; set; }
    }
}