using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.User
{
    public enum ModelEnumStatusUser
    {
        Locked,
        Confirmed,
        NConfirmed
    }

    public class ModelStatus
    {
        public ModelEnumStatusUser Id { get; set; }

        public string Name { get; set; }
        
    }
}
