using Application.DAOInterfaces;
using Shared.Models;

namespace FileData.DAOImpls;

public class UserDao : IUserDao
{
    public readonly FileContext context;

    public UserDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User toCreateUser)
    {
        int userId = 1;

        if (context.Users.Any())
        {
            userId = context.Users.Max(user => user.UserId);
            userId++;
        }

        toCreateUser.UserId = userId;

        context.Users.Add(toCreateUser);
        context.SaveChanges();
        return Task.FromResult(toCreateUser);
    }

    public Task<User> GetByUsername(string username)
    {
        User? existingUser =
            context.Users.FirstOrDefault(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult<User>(existingUser);
    }
}