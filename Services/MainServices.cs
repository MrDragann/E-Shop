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
            Register = new RegisterServices();
            Product = new ProductServices();
            Admin = new AdminServices();
    }
        public IUserServices Users { get; set; }

        public IRegisterServices Register { get; set; }

        public IProductServices Product { get; set; }

        public IAdminServices Admin { get; set; }
    }
}
