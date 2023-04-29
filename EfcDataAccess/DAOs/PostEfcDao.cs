using Application.DAOInterfaces;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    public Task<Post> CreateAsync(Post post, int forumId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post?> GetPostByIdAsync(int forumId, int postId)
    {
        throw new NotImplementedException();
    }

    public Task<Post> CreateAsync(Post createdPost)
    {
        throw new NotImplementedException();
    }
}