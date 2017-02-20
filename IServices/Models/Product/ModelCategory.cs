using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models
{
    public class ModelCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Parent { get; set; }

        public int? ParentId { get; set; }

        public List<Category> Сhild { get; set; }

        public List<Product> Products { get; set; }
    }
}
