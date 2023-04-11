using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User?> CreateAsync(UserDto userDto)
    {
        IEnumerable<User?> allUsers = await userDao.GetAllUsersAsync();
        User? existingUser = allUsers.FirstOrDefault(user =>
            user.Username.Equals(userDto.Username, StringComparison.OrdinalIgnoreCase));
        if (existingUser != null)
        {
            throw new Exception("Username should be unique. Username already taken");
        }


        ValidateUserData(userDto);

        User? toCreate = new User(userDto.Username, userDto.Password);
        // {
        //     Username = userDto.Username,
        //     Password = userDto.Password
        // };

        User? createdUser = await userDao.CreateAsync(toCreate);
        return createdUser;
    }

    public async Task<User> ValidateUser(UserDto userDto)
    {
        IEnumerable<User?> allUsers = await userDao.GetAllUsersAsync();
        User? existingUser = allUsers.FirstOrDefault(user =>
            user.Username.Equals(userDto.Username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(userDto.Password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    private static void ValidateUserData(UserDto userDto)
    {
        string userName = userDto.Username;
        string password = userDto.Password;

        if (userName.Length is < 3 or > 15)
        {
            throw new Exception("Username must be between 3 and 15 characters long");
        }

        if (password.Length is < 7 or > 16)
        {
            throw new Exception("Password must be between 7 and 16 characters long");
        }
    }
}