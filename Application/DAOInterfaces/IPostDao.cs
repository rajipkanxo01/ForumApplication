using Shared.DTOs;
using Shared.Models;

namespace Application.DAOInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post, int forumId);
    Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int id);

    Task<Post?> GetPostByIdAsync(int forumId, int postId);

    // Task<IEnumerable<Post>> GetAllPostsAsync();

    // Task<Comment> CreateCommentAsync(int id, Comment comment);
}