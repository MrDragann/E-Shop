using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    /// <summary>
    /// Класс модели слайдера
    /// </summary>
    public class ModelSlider
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        /// <value>Идентификатор товара</value>
        public int ProductId { get; set; }
        /// <summary>
        /// Ссылка на товар
        /// </summary>
        /// <value>Модель товара</value>
        public ModelProduct Product { get; set; }
        /// <summary>
        /// Дата добавления в слайдер
        /// </summary>
        /// <value>Дата добавления</value>
        public DateTime CreateDate { get; set; }
    }
}
