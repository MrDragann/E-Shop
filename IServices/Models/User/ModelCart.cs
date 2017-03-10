using System.Collections.Generic;
using System.Linq;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели корзины
    /// </summary>
    public class ModelCart
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        public int ProductId { get; set; }
        /// <summary>
        /// Модель товара
        /// </summary>
        /// <value>Товар</value>
        public ModelProduct Product { get; set; }
        /// <summary>
        /// Количество единиц
        /// </summary>
        /// <value>Количество</value>
        public int Quantity { get; set; }
    }

    /// <summary>
    /// Класс реализующий работу с корзиной
    /// </summary>
    public class ModelCarts
    {
        /// <summary>
        /// Список товаров в корзине
        /// </summary>
        /// <value>Товары в корзине</value>
        public List<ModelCart> ProductCart { get; set; }
        /// <summary>
        /// Вывод содержимого корзины
        /// </summary>
        /// <returns>List&lt;ModelCart&gt;.</returns>
        public List<ModelCart> GetCart() { return ProductCart; }

        /// <summary>
        /// Суммарная стоимость корзины
        /// </summary>
        /// <returns>System.Decimal.</returns>
        public decimal ComputeTotalValue()
        {
            return ProductCart.Sum(e => e.Product.Price * e.Quantity);
        }
    }
}
