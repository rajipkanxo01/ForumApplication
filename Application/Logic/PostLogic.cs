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

    public async Task<Post> CreateAsync(CreatePostDto createPostDto)
    {
        PostDto postDto = createPostDto.PostDto!;
        
        Post createdPost = new Post ()
        {
            Title = postDto.Title,
            Body = postDto.Body,
            CreatedBy = postDto.CreatedBy
        };
        Post post = await postDao.CreateAsync(createdPost,createPostDto.ForumId);
        return post;
    }

    public async Task<Post?> GetPostByIdAsync(int postId)
    {
        Post? post = await postDao.GetPostByIdAsync(postId);
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