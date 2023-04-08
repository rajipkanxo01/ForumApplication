namespace Shared.Models;

public class Forum
{
    public int ForumId { get; set; }
    public string? CreatedBy { get; set; }
    public string ForumName { get; set; }
    public string ForumDescription { get; set; }
}