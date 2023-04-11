using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(CreatePostDto postDto);
    Task<Post?> GetPostByIdAsync(int postId);
    Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int forumId);
}