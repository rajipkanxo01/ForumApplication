using System.Security.Claims;
using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IUserService
{
    Task<User> RegisterUserAsync(UserDto userDto);
    Task LoginAsync(UserDto dto);
    Task LogOutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}