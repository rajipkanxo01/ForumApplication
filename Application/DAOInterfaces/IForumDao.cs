using System.Collections;
using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IForumDao
{
    Task<Forum?> CreateAsync(Forum toCreateForum);
    Task<IEnumerable<Forum?>> GetAllForumsAsync();
    Task<Forum?> GetForumByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllPostsOfForum(int id);
}