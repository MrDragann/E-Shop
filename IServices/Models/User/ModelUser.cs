using System.Collections.Generic;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели пользователя для авторизации
    /// </summary>
    public class ModelUser
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
        /// Пароль пользователя
        /// </summary>
        /// <value>Пароль</value>
        public string Password { get; set; }

        /// <summary>
        /// Авторизован пользователь или нет
        /// </summary>
        /// <value><c>true</c> если пользователь авторизован; иначе, <c>false</c>.</value>
        public bool IsAuth { get; set; }
        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        /// <value>Список ролей</value>
        public List<ModelRole> Roles { get; set; }
    }
}
