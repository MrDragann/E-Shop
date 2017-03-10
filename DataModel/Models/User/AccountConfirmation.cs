using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models
{
    /// <summary>
    /// Класс модели подтверждения аккаунта
    /// </summary>
    public class AccountConfirmation
    {
        [Key]
        [ForeignKey("UserOf")]
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор</value>
        public int UserId { get; set; }
        /// <summary>
        /// Статус подтверждения аккаунта
        /// </summary>
        /// <value><c>true</c> если [аккаунт подтвержден]; иначе, <c>false</c>.</value>
        public bool ConfirmedEmail { get; set; }
        /// <summary>
        /// Код, необходимый для подтверждения аккаунта
        /// </summary>
        /// <value>Код подтверждения</value>
        public string ConfirmationCode { get; set; }
        /// <summary>
        /// Ссылка на пользователя
        /// </summary>
        /// <value>Пользователь</value>
        public User UserOf { get; set; }
    }
}
