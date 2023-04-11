namespace Shared.DTOs;

public class ForumDto
{
    public string? CreatedBy { get; set; }
    public string? ForumTitle { get; set; }
    public string? ForumDescription { get; set; }

    public ForumDto(string? createdBy, string? forumTitle, string? forumDescription)
    {
        CreatedBy = createdBy;
        ForumTitle = forumTitle;
        ForumDescription = forumDescription;
    }
}