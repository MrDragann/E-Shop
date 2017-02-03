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
    }
}
