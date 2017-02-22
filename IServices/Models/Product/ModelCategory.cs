using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.Product
{
    public class ModelCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ModelCategory Parent { get; set; }

        public int? ParentId { get; set; }

        public List<ModelCategory> Child { get; set; }
    }
}
