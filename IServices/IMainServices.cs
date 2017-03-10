using IServices.SubInterface;

/// <summary>
/// Содержит интерфейсы библиотеки классов Services,  а также модели для работы с DataModel.
/// </summary>
namespace IServices
{
    /// <summary>
    /// Определяет методы публичной части сайта
    /// </summary>
    public interface IMainServices
    {
        /// <summary>
        /// Определяет методы связанные с пользователями
        /// </summary>
        IUserServices Users { get; set; }
        /// <summary>
        /// Определяет методы связанные с товарами
        /// </summary>
        IProductServices Product { get; set; }
        
    }
}
