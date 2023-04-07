using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }

    public Task<Post> CreateAsync(PostDto postDto)
    {
        Post createdPost = new Post
        {
            Title = postDto.Title,
            Body = postDto.Body,
            BelongsToId = postDto.BelongsToId,
            CreatedBy = postDto.CreatedBy
        };
        postDao.CreateAsync(createdPost);
        return Task.FromResult(createdPost);
    }

    public Task<Post?> GetPostByIdAsync(int postId)
    {
        return postDao.GetPostByIdAsync(postId);
    }

    public Task<IEnumerable<Post>> GetPostByForumAsync(int forumId)
    {
        IEnumerable<Post> allPostsAsync = postDao.GetAllPostsAsync().Result;
        IEnumerable<Post> posts = allPostsAsync.Where(post => post.BelongsToId == forumId);
        return Task.FromResult(posts);

    }
}