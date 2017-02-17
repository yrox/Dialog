﻿using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<UserDTO> GetAll();

        UserDTO GetByName(string name);

        UserDTO GetById(int id);

        void Login(UserDTO userData);

        void Register(UserDTO userData);

        void Logout();
    }
}