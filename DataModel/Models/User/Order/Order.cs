using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models
{
    /// <summary>
    /// Класс модели заказа
    /// </summary>
    public class Order
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
        /// Ссылка на пользователя
        /// </summary>
        /// <value>Список пользователей</value>
        public User User { get; set; }
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор статуса</value>
        public EnumStatusOrder StatusOrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        /// <value>Дата заказа</value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Общая стоимость заказа
        /// </summary>
        public double TotalPrice { get; set; }
        /// <summary>
        /// Ссылка на список товаров в заказе
        /// </summary>
        /// <value>Список товаров в заказе</value>
        public List<OrderProduct> OrderProduct { get; set; }
        
    }
}
