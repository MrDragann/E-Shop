using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.User
{
    public class ModelCart
    {
        public List<CartLine> lineCollection = new List<CartLine>();
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="product">Модель товара</param>
        /// <param name="quantity">Количество</param>
        public void AddToCart(ModelProduct product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLine(ModelProduct product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }
        /// <summary>
        /// Суммарная стоимость корзины
        /// </summary>
        /// <returns></returns>
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        /// <summary>
        /// Очистка корзины
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ModelProduct Product { get; set; }

    }
}
