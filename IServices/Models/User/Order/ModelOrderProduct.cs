using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели товаров заказа
    /// </summary>
    public class ModelOrderProduct
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        /// <value>Идентификатор заказа</value>
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        public int ProductId { get; set; }
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
        /// <summary>
        /// Ссылка на заказы
        /// </summary>
        /// <value>Заказы</value>
        public ModelOrder Order { get; set; }
        /// <summary>
        /// Ссылка на товары
        /// </summary>
        /// <value>Товары</value>
        public ModelProduct Product { get; set; }
    }
}
