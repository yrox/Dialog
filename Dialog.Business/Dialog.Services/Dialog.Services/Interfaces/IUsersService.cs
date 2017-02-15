﻿using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<UserDTO> GetAll();

        int GetIdByName(string name);

        string GetNameById(int id);

        void Login(UserDTO userData);

        void Register(UserDTO userData);

        void Logout();
    }
}
