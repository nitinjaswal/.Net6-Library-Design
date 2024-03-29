﻿using Library_Business.Dtos;
using Library_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Business.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<UserDto>> GetUsers();
        public Task<UserDto> GetUserByEmail(string email);
        public Task<int> CreateUser(User createUser);
    }
}
