using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public IMainServices Services { get; set; }

        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
        }
        
    }
}