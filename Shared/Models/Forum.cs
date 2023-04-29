using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Forum
{
    [Key]
    public int ForumId { get; set; }
    public User? CreatedBy { get; set; }
    public string? ForumName { get; set; }
    public string? ForumDescription { get; set; }
    public ICollection<Post>? Posts { get; set; }

    public Forum(User? createdBy, string? forumName, string? forumDescription)
    {
        CreatedBy = createdBy;
        ForumName = forumName;
        ForumDescription = forumDescription;
    }

    public Forum()
    {
    }
}