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

    public Task<Post> CreateAsync(Post post, int forumId)
    {
        Forum? forum = fileContext.Forums.FirstOrDefault((forum => forum.ForumId == forumId))!;

        int postId = 1;

        ICollection<Post> posts = forum.Posts!;


        if (posts.Any())
        {
            postId = posts.Max(p => p.PostId);
            postId++;
        }

        post.PostId = postId;
        post.CreatedOn = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm");
        // post.Comments = new List<Comment>();

        posts.Add(post);
        fileContext.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllPostsByForumIdAsync(int id)
    {
        Forum? forum = fileContext.Forums.FirstOrDefault((forum => forum.ForumId == id))!;
        IEnumerable<Post> forumPosts = forum.Posts!.AsEnumerable();
        return Task.FromResult(forumPosts);
    }

    public Task<Post?> GetPostByIdAsync(int forumId, int postId)
    {
        Forum? forum = fileContext.Forums!.FirstOrDefault(forum => forum.ForumId == forumId)!;

        Post post = forum.Posts!.FirstOrDefault(p => p.PostId == postId)!;

        return Task.FromResult(post)!;
    }

    // public Task<IEnumerable<Post>> GetAllPostsAsync()
    // {
    //     IEnumerable<Post> posts = fileContext.Posts.AsEnumerable();
    //     return Task.FromResult(posts);
    // }

    // public Task<Comment> CreateCommentAsync(int id, Comment comment)
    // {
    //     int commentId = 1;
    //     Post? post = GetPostByIdAsync(id).Result;
    //
    //     if (post!.Comments!.Any())
    //     {
    //         commentId = post.Comments!.Max(p => p.CommentId);
    //         commentId++;
    //     }
    //
    //     comment.CommentId = commentId;
    //     comment.CreatedOn = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm");
    //
    //     post.Comments!.Add(comment);
    //     fileContext.SaveChanges();
    //     return Task.FromResult(comment);
    // }
}