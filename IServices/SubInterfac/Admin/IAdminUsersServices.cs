using IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.SubInterfac.Admin
{
    public interface IAdminUsersServices
    {
        /// <summary>
        /// Вывод всех пользовотелей 
        /// </summary>
        /// <returns></returns>
        List<ModelUserInfo> Users();
        /// <summary>
        /// Удаление выбраных пользователей
        /// </summary>
        /// <param name="id">Список пользователй</param>
        void DeleteUsers(List<int> id);
        /// <summary>
        /// Блокировка выбраных пользователей
        /// </summary>
        /// <param name="id">Список пользователй</param>
        void BLockUsers(List<int> id);
        /// <summary>
        /// Добавляет роль пользователю 
        /// </summary>
        /// <param name="id">Список пользователй</param>
        /// <param name="roleId">Выбранная роль</param>
        void EditRole(List<int> id, int roleId);
    }
}
