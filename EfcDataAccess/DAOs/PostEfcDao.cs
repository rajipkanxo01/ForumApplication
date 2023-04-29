using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly ForumContext context;

    public PostEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post, int forumId)
    {
        Forum? forum = await context.Forums.FirstOrDefaultAsync(forum => forum.ForumId == forumId);

        if (forum == null)
        {
            throw new Exception($"Forum with id {forumId} not found!!");
        }

        post.CreatedOn = DateTime.Now.ToString();
        forum.Posts!.Add(post);
        await context.SaveChangesAsync();
        return post;

        // }
    }

    public async Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int id)
    {
        Forum? forum = await context.Forums.Include(forum => forum.Posts)
            .FirstOrDefaultAsync(forum => forum.ForumId == id);

        if (forum == null)
        {
            throw new Exception($"Forum with id {id} not found");
        }

        IEnumerable<Post>? posts = forum!.Posts;
        return posts;
    }

    public async Task<Post?> GetPostByIdAsync(int forumId, int postId)
    {
        Post? post = await context.Posts.FirstOrDefaultAsync(post => post.PostId == postId);
        return post;
    }
}