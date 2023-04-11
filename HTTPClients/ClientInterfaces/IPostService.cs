using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IPostService
{
    Task<ICollection<Post>> GetPostsByForumIdAsync(int id);
    Task<Post?> CreateAsync(CreatePostDto postDto);
    Task<Post?> GetPostByIdAsync(int forumId, int postId);
}