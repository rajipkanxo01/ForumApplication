namespace Shared.Models;

public class Forum
{
    public int ForumId { get; set; }
    public string ForumName { get; set; }

    public Forum(string forumName)
    {
        ForumName = forumName;
    }
}