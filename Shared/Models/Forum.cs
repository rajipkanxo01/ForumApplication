using System.Collections;
using System.ComponentModel;

namespace Shared.Models;

public class Forum
{
    public int ForumId { get; set; }
    public string? CreatedBy { get; set; }
    public string? ForumName { get; set; }
    public string? ForumDescription { get; set; }
    public ICollection<Post>? Posts { get; set; }

    public Forum(string? createdBy, string? forumName, string? forumDescription)
    {
        CreatedBy = createdBy;
        ForumName = forumName;
        ForumDescription = forumDescription;
    }
}