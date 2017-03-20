using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели заказа
    /// </summary>
    public class ModelOrder
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        /// <value>Идентификатор пользователя</value>
        public int UserId { get; set; }
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор статуса</value>
        public ModelEnumStatusOrder StatusOrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        /// <value>Дата заказа</value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Дата получения
        /// </summary>
        /// <value>Дата получения</value>
        public DateTime ReceivingDate { get; set; }
        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// Адрес заказа
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ссылка на список товаров в заказе
        /// </summary>
        /// <value>Список товаров в заказе</value>
        public List<ModelOrderProduct> OrderProduct { get; set; }
        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public ModelUserInfo User { get; set; }
    }
}
