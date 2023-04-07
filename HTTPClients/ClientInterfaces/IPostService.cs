using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IPostService
{
    Task<Post?> CreateAsync(PostDto postDto);
    Task<ICollection<Post>> GetPostsByForumId(int id);

}