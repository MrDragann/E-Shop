using IServices.SubInterface;

namespace IServices
{
    /// <summary>
    /// Определяет методы публичной части сайта
    /// </summary>
    public interface IAdminServices
    {
        /// <summary>
        /// Определяет методы связанные с пользователями
        /// </summary>
        IAdminUsersServices Users { get; set; }
        /// <summary>
        /// Определяет методы связанные с товарами
        /// </summary>
        IAdminProductServices Products { get; set; }
    }
}
