using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(UserDto userDto);

    Task<UserDto> GetUserByUsernameAsync(string username);
}