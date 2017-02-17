using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAdminServices
    {
        List<UserInfo> Users();
        void DeleteUsers(List<int> id);
    }
}
