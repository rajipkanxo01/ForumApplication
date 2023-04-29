using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? CreatedBy { get; set; }
    [Key] public int PostId { get; set; }

    public string? CreatedOn { get; set; }
    // public Forum? forum { get; set}
    // public ICollection<Comment>? Comments { get; set; }

    public Post()
    {
    }
}