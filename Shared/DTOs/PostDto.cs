using Shared.Models;

namespace Shared.DTOs;

public class PostDto
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? CreatedBy { get; set; }
    public Forum BelongsToForum { get; set; }

    public PostDto(string? title, string? body, string? createdBy, Forum belongsToForum)
    {
        Title = title;
        Body = body;
        CreatedBy = createdBy;
        this.BelongsToForum = BelongsToForum;
    }
}