using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User toCreateUser);
    Task<User> GetByUsername(string username);
    

}