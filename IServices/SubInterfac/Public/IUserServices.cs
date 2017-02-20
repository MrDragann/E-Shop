﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IUserServices
    {
        #region Registration
        bool Login(string userName, string password);

        bool CheckRole(string userName, string role);

        void ResetPassword(string email, string password, string salt);
        #endregion
    }
}