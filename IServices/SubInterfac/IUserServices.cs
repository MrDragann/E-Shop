using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IUserServices
    {
        bool Login(string userName, string password);
    }
}
