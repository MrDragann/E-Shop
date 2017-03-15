using System;
using System.Collections.Generic;

namespace DataModel.Models
{
    /// <summary>
    /// Класс модели пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        /// <value>Имя пользователя</value>
        public string UserName { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        /// <value>Эл.адрес</value>
        public string Email { get; set; }
        /// <summary>
        /// Фото пользователя
        /// </summary>
        /// <value>Фото</value>
        public string Photo { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        /// <value>Пароль</value>
        public string Password { get; set; }
        /// <summary>
        /// Соль пользователя
        /// </summary>
        /// <value>Соль</value>
        public string Salt { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        /// <value>Дата регистрации</value>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Дата последний авторизции пользователя
        /// </summary>
        /// <value>Дата последний авторизции</value>
        public DateTime LastLoginDate { get; set; }
        /// <summary>
        /// Идентификатор статуса пользователя
        /// </summary>
        /// <value>Идентификатор статуса пользователя</value>
        public EnumStatusUser StatusUserId { get; set; }
        /// <summary>
        /// Ссылка на модель подтверждения аккаунта
        /// </summary>
        /// <value>Подтверждение аккаунта</value>
        public AccountConfirmation AccountConfirmation { get; set; }
        /// <summary>
        /// Ссылка на модель профиля пользователя
        /// </summary>
        /// <value>Профиль пользователя</value>
        public UserProfile UserProfile { get; set; }
        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        /// <value>Список ролей</value>
        public List<Role> Roles { get; set; }
        /// <summary>
        /// Ссылка на список заказов
        /// </summary>
        /// <value>Список заказов</value>
        public List<Order> Order { get; set; }
    }
    /// <summary>
    /// Возможные статусы пользователя
    /// </summary>
    public enum EnumStatusUser
    {
        /// <summary>
        /// Заблокирован
        /// </summary>
        Locked,
        /// <summary>
        /// Подтвержден
        /// </summary>
        Confirmed,
        /// <summary>
        /// Не подтвержден
        /// </summary>
        NConfirmed
    }

    /// <summary>
    /// Класс модели статуса пользователя
    /// </summary>
    public class StatusUser
    {
        /// <summary>
        /// Идентификатор статуса пользователя
        /// </summary>
        /// <value>Идентификатор</value>
        public EnumStatusUser Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public List<User> Users { get; set; }
    }
}