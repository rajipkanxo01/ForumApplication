namespace Shared.Models;

public class Post
{
    public string Title { get; set; }
    public string Body { get; set; }
    public User CreatedBy { get; set; }
    public Forum BelongsTo { get; set; }
    public int PostId { get; set; }

    public Post(string title, string body, User createdBy, Forum belongsTo)
    {
        Title = title;
        Body = body;
        CreatedBy = createdBy;
        BelongsTo = belongsTo;
    }
}