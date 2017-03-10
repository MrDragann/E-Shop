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
        public ModelEnumStatusUser Status { get; set; }
        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        /// <value>Список ролей</value>
        public List<ModelRole> Roles { get; set; }
    }
}
