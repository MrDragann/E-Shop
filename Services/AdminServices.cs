using IServices;
using IServices.SubInterface;
using Services.Admin;

namespace Services
{
    /// <summary>
    /// Управление админкой
    /// </summary>
    /// <seealso cref="IServices.IAdminServices" />
    public class AdminServices : IAdminServices
    {
        public AdminServices()
        {
            Users = new AdminUsersServices();
            Products = new AdminProductsServices();
        }
        public IAdminUsersServices Users { get; set; }
        public IAdminProductServices Products { get; set; }

    }
}
