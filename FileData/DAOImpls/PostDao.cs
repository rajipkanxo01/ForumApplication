using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOImpls;

public class PostDao : IPostDao
{
    private readonly FileContext fileContext;

    public PostDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;

        if (fileContext.Posts.Any())
        {
            postId = fileContext.Posts.Max(p => p.PostId);
            postId++;
        }

        post.PostId = postId;
        post.CreatedOn = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm");

        fileContext.Posts.Add(post);
        fileContext.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<Post?> GetPostByIdAsync(int id)
    {
        Post? postById = fileContext.Posts.FirstOrDefault((post => post.PostId == id));
        return Task.FromResult(postById);
    }

    public Task<IEnumerable<Post>> GetAllPostsAsync()
    {
        IEnumerable<Post> posts = fileContext.Posts.AsEnumerable();
        return Task.FromResult(posts);
    }

    public Task<IEnumerable<Post>> GetAllPostWithBelongsToIdAsync(int id)
    {
        IEnumerable<Post> allPostsWithId = fileContext.Posts.Where(post => post.BelongsToId == id);
        return Task.FromResult(allPostsWithId);
    }
}