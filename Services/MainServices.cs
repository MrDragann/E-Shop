using IServices;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public class MainServices : IMainServices
    {
        public MainServices()
        {
            Users = new UserServices();
            Product = new ProductServices();
    }
        public IUserServices Users { get; set; }

        public IProductServices Product { get; set; }
    }
}
