using IServices.SubInterfac.Admin;

namespace IServices
{
    public interface IAdminServices
    {
        /// <summary>
        /// Реализует методы связанные с пользователями
        /// </summary>
        IAdminUsersServices Users { get; set; }
        /// <summary>
        ///Реализует методы связанные с товарами
        /// </summary>
        IAdminProductServices Products { get; set; }
    }
}
