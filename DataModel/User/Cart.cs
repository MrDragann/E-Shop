using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Cart
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public Product Product { get; set; }

        public List<User> User { get; set; }
    }
}
