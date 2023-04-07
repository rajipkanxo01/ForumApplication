using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostDto postDto);
    Task<Post?> GetPostByIdAsync(int postId);
    Task<IEnumerable<Post>> GetPostByForumAsync(int forumId);
    
    
}