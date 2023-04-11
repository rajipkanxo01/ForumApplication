namespace Shared.DTOs;

public class PostDto
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? CreatedBy { get; set; }

    public PostDto(string? title, string? body, string? createdBy)
    {
        Title = title;
        Body = body;
        CreatedBy = createdBy;
    }
}