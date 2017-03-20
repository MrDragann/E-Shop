using System.ComponentModel;

namespace IServices.Models
{
    /// <summary>
    /// Возможные статусы пользователя
    /// </summary>
    public enum ModelEnumStatusUser
    {
        /// <summary>
        /// Заблокирован
        /// </summary>
        [Description("Заблокирован")]
        Locked,
        /// <summary>
        /// Подтвержден
        /// </summary>
        [Description("Подтвержден")]
        Confirmed,
        /// <summary>
        /// Не подтвержден
        /// </summary>
        [Description("Не подтвержден")]
        NConfirmed
    }
    /// <summary>
    /// Класс модели статуса пользователя
    /// </summary>
    public class ModelStatusUser
    {
        /// <summary>
        /// Идентификатор статуса пользователя
        /// </summary>
        /// <value>Идентификатор</value>
        public ModelEnumStatusUser Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        
    }
}
