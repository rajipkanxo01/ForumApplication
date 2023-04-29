using Application.DAOInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class ForumEfcDao : IForumDao
{
    private readonly ForumContext context;

    public ForumEfcDao(ForumContext context)
    {
        this.context = context;
    }

    public async Task<Forum?> CreateAsync(Forum toCreateForum)
    {
        EntityEntry<Forum> createdForum = await context.Forums.AddAsync(toCreateForum);
        await context.SaveChangesAsync();
        return createdForum.Entity;
    }

    public async Task<IEnumerable<Forum?>> GetAllForumsAsync()
    {
        IEnumerable<Forum?> forums = await context.Forums.ToListAsync();
        await context.SaveChangesAsync();
        return forums;
    }

    public async Task<Forum?> GetForumByIdAsync(int id)
    {
        Forum? forumById = await context.Forums.FirstOrDefaultAsync(forum => forum.ForumId == id);
        return forumById;
    }

    public async Task<IEnumerable<Post>> GetAllPostsOfForum(int id)
    {
        // var postsForForum = context.Posts.Where(post => post.Fo)
        /*Forum? forum = await context.Forums.Include(forum => forum.Posts)
            .FirstOrDefaultAsync(forum => forum.ForumId == id);

        if (forum == null)
        {
            throw new Exception($"Forum with id {id} not found");
        }

        IEnumerable<Post>? posts = forum!.Posts;
        return posts;*/
        throw new NotImplementedException();
    }
}