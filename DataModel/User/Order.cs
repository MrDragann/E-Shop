using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public EnumStatusOrder StatusOrderId { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime OrderDate { get; set; }

        public List<OrderProduct> OrderProduct { get; set; }

        public List<User> User { get; set; }
    }

    public class OrderProduct
    {
        /// <summary>
        /// Id заказа
        /// </summary>
        [Key, ForeignKey("Order"), Column(Order = 1)]
        public int OrderId { get; set; }
        /// <summary>
        /// Id товара
        /// </summary>
        [Key, ForeignKey("Product"), Column(Order = 2)]
        public int ProductId { get; set; }
        /// <summary>
        /// Количество товаров
        /// </summary>
        public int Quantity { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }

    public class StatusOrder
    {
        /// <summary>
        /// Id статуса заказа
        /// </summary>
        public EnumStatusOrder Id { get; set; }
        /// <summary>
        /// Имя статуса
        /// </summary>
        public string Name { get; set; }

        public List<Order> Orders { get; set; }
    }

    public enum EnumStatusOrder
    {
        Cart,
        Processing,
        Ordered,
        Confirmed,
        Denial
    }
}
