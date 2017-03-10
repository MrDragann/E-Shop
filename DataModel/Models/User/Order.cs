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
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор статуса</value>
        public EnumStatusOrder StatusOrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        /// <value>Дата заказа</value>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Ссылка на список товаров в заказе
        /// </summary>
        /// <value>Список товаров в заказе</value>
        public List<OrderProduct> OrderProduct { get; set; }
        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public List<User> User { get; set; }
    }
    /// <summary>
    /// Класс модели товаров заказа
    /// </summary>
    public class OrderProduct
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        /// <value>Идентификатор заказа</value>
        [Key, ForeignKey("Order"), Column(Order = 1)]
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        [Key, ForeignKey("Product"), Column(Order = 2)]
        public int ProductId { get; set; }
        /// <summary>
        /// Количество товаров
        /// </summary>
        /// <value>Количество</value>
        public int Quantity { get; set; }
        /// <summary>
        /// Ссылка на заказы
        /// </summary>
        /// <value>Заказы</value>
        public Order Order { get; set; }
        /// <summary>
        /// Ссылка на товары
        /// </summary>
        /// <value>Товары</value>
        public Product Product { get; set; }
    }
    /// <summary>
    /// Класс модели статуса заказа
    /// </summary>
    public class StatusOrder
    {
        /// <summary>
        /// Идентификатор статуса заказа
        /// </summary>
        /// <value>Идентификатор</value>
        public EnumStatusOrder Id { get; set; }
        /// <summary>
        /// Наименование статуса
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }
        /// <summary>
        /// Ссылка на список заказов
        /// </summary>
        /// <value>Список заказов</value>
        public List<Order> Orders { get; set; }
    }

    /// <summary>
    /// Возможные статусы заказа
    /// </summary>
    public enum EnumStatusOrder
    {
        /// <summary>
        /// Корзина
        /// </summary>
        Cart,
        /// <summary>
        /// Обработка
        /// </summary>
        Processing,
        /// <summary>
        /// Заказан
        /// </summary>
        Ordered,
        /// <summary>
        /// Подтвержден
        /// </summary>
        Confirmed,
        /// <summary>
        /// Отказ
        /// </summary>
        Denial
    }
}
