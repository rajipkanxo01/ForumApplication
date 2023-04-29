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

    public async Task<Post> CreateAsync(PostDto createPostDto)
    {
        Post createdPost = new Post()
        {
            Title = createPostDto.Title,
            Body = createPostDto.Body,
            CreatedBy = createPostDto.CreatedBy
        };
        Post post = await postDao.CreateAsync(createdPost);
        return post;
    }

    public async Task<Post?> GetPostByIdAsync(int forumId, int postId)
    {
        Post? post = await postDao.GetPostByIdAsync(forumId, postId);
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int forumId)
    {
        IEnumerable<Post> posts = await postDao.GetAllPostsByForumIdAsync(forumId);
        return posts;
    }

    /*public Task<Comment> CreateCommentAsync(int id, CommentDto commentDto)
    {
        Comment createdComment = new Comment
        {
            CommentBody = commentDto.CommentBody,
            PostedByUserId = commentDto.PostedByUserId
        };
        postDao.CreateCommentAsync(id, createdComment);
        return Task.FromResult(createdComment);
    }*/
}