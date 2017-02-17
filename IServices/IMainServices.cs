using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IMainServices
    {
        IUserServices Users { get; set; }

        IRegisterServices Register { get; set; }

        IProductServices Product { get; set; }

        IAdminServices Admin { get; set; }
    }
}
