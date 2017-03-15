using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models
{
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
        /// Ссылка на заказы
        /// </summary>
        /// <value>Заказы</value>
        public Order Order { get; set; }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        [Key, ForeignKey("Product"), Column(Order = 2)]
        public int ProductId { get; set; }
        /// <summary>
        /// Ссылка на товары
        /// </summary>
        /// <value>Товары</value>
        public Product Product { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        /// <value>Цена</value>
        public int Price { get; set; }
        /// <summary>
        /// Количество товаров
        /// </summary>
        /// <value>Количество</value>
        public int Quantity { get; set; }
    }
}
