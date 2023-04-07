namespace Shared.Models;

public class Post
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? CreatedBy { get; set; }
    public int BelongsToId { get; set; }
    public int PostId { get; set; }

   
}