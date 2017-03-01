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
        /// Фото пользователя
        /// </summary>
        public string Photo { get; set; }
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
        /// <summary>
        /// Id статуса заказа
        /// </summary>
        public EnumStatusUser StatusUserId { get; set; }

        public AccountConfirmation AccountConfirmation { get; set; }

        public List<Role> Roles { get; set; }

        public List<Order> Order { get; set; }
    }

    public enum EnumStatusUser
    {
        Locked,
        Confirmed,
        NConfirmed
    }

    public class StatusUser
    {
        /// <summary>
        /// Id статуса пользователя
        /// </summary>
        public EnumStatusUser Id { get; set; }
        /// <summary>
        /// Имя статуса
        /// </summary>
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}