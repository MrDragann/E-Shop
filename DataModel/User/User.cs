using System;
using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        /// <summary>
        /// Id Пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Почта пользователя 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Соль пользователя
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Время последний авторизции пользователя
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        public EnumStatusUser StatusUserId { get; set; }

        // Ссылка на профиль
        public AccountConfirmation AccountConfirmation { get; set; }

        public List<Role> Roles { get; set; }
    }

    public enum EnumStatusUser
    {
        Locked,
        Confirmed,
        NConfirmed
    }

    public class StatusUser
    {
        public EnumStatusUser Id { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}