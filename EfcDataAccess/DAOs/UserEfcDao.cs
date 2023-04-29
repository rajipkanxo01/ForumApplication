using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;


namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly ForumContext context;

    public UserEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<User?> CreateAsync(User? toCreateUser)
    {
        Task<User?> existingUser = GetByUsernameAsync(toCreateUser!.Username);

        if (existingUser == null)
        {
            throw new Exception("Username already exists!!");
        }

        EntityEntry<User> createdUser = (await context.Users.AddAsync(toCreateUser))!;
        await context.SaveChangesAsync();
        return createdUser.Entity;
    }

    public async Task<IEnumerable<User?>> GetAllUsersAsync()
    {
        IEnumerable<User?> allUsers = context.Users.AsQueryable();
        return allUsers;
    }

    public async Task<User?> GetByUsernameAsync(string? username)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.Username.ToLower().Equals(username.ToLower())
        );
        return existing;
    }
}