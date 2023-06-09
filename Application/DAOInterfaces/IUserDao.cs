﻿using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    Task<User?> CreateAsync(User? toCreateUser);
    Task<IEnumerable<User?>> GetAllUsersAsync();
    Task<User?> GetByUsernameAsync(string? username);


}