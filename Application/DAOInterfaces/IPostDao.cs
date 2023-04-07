using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetPostByIdAsync(int id);

    Task<IEnumerable<Post>> GetAllPostsAsync();
    Task<IEnumerable<Post>> GetAllPostWithBelongsToIdAsync(int id);
}