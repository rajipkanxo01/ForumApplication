using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostDto postDto);
    Task<Post?> GetPostByIdAsync(int forumId, int postId);
    Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int forumId);
}