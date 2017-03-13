using IServices.Models;
using System.Collections.Generic;

namespace IServices.SubInterface
{
    /// <summary>
    /// Определяет методы связанные с пользователями
    /// </summary>
    public interface IAdminUsersServices
    {
        /// <summary>
        /// Вывод всех пользовотелей
        /// </summary>
        /// <returns>List&lt;ModelUserInfo&gt;.</returns>
        List<ModelUserInfo> Users();
        /// <summary>
        /// Удаление выбраных пользователей
        /// </summary>
        /// <param name="id">Список пользователй</param>
        void DeleteUser(int id);
        /// <summary>
        /// Изменение статуса пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="statusId">Выбранный статус</param>
        void EditStatus(int userId, ModelEnumStatusUser statusId);
        /// <summary>
        /// Изменение роли пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="roleId">Выбранная роль</param>
        void EditRole(int userId, ModelEnumTypeRoles roleId);

        /// <summary>
        /// Вывод всех заказов
        /// </summary>
        /// <returns>List&lt;ModelOrder&gt;.</returns>
        List<ModelOrder> Orders();
    }
}
