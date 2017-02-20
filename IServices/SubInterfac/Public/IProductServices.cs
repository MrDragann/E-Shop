using DataModel;
using IServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IProductServices
    {
        List<ModelProductPreview> ProductsPreview();
        List<ModelProduct> ProductsDetails();
        List<ModelCategory> GetCategory();
    }
}
