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

    public Task<User?> CreateAsync(User? toCreateUser)
    {
        context.Users.Add(toCreateUser);
        context.SaveChanges();
        return Task.FromResult(toCreateUser);
    }

    public Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        IEnumerable<User?> users = context.Users.AsEnumerable();
        return Task.FromResult(users);
    }

    public Task<User?> GetByUsernameAsync(string? username)
    {
        throw new NotImplementedException();
    }
}