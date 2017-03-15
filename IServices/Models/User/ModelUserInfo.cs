using System;
using System.Collections.Generic;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели пользователя
    /// </summary>
    public class ModelUserInfo
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
        public ModelEnumStatusUser StatusUserId { get; set; }
        /// <summary>
        /// Ссылка на модель профиля пользователя
        /// </summary>
        /// <value>Профиль пользователя</value>
        public ModelUserProfile UserProfile { get; set; }
        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        /// <value>Список ролей</value>
        public List<ModelRole> Roles { get; set; }
        /// <summary>
        /// Ссылка на список заказов
        /// </summary>
        /// <value>Список заказов</value>
        public List<ModelOrder> Order { get; set; }
    }
}
