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
