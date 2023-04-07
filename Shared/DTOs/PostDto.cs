namespace Shared.DTOs;

public class PostDto
{
    public int BelongsToId { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? CreatedBy { get; set; }
}