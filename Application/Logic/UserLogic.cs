using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserDto userDto)
    {
        User? existingUser = await userDao.GetByUsername(userDto.Username);
        if (existingUser != null)
        {
            throw new Exception("Username should be unique. Username already taken");
        }

        ValidateUserData(userDto);

        User toCreate = new User()
        {
            Username = userDto.Username,
            Password = userDto.Password
        };

        User createdUser = await userDao.CreateAsync(toCreate);
        return createdUser;
    }

    public Task<User> GetAsync(string username)
    {
        throw new NotImplementedException();
    }

    private static void ValidateUserData(UserDto userDto)
    {
        string userName = userDto.Username;
        string password = userDto.Password;

        if (userName.Length < 3 && userName.Length > 15)
        {
            throw new Exception("Username must be between 3 and 15 characters long");
        }

        if (password.Length < 7 && password.Length > 16)
        {
            throw new Exception("Password must be between 7 and 16 characters long");
        }
    }
}