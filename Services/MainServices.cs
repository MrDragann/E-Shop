using IServices;
using IServices.SubInterface;
using Services.Public;

/// <summary>
/// Содержит методы функционала веб-приложения.
/// </summary>
namespace Services
{
    /// <summary>
    /// Управление публичной частью
    /// </summary>
    /// <seealso cref="IServices.IMainServices" />
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
