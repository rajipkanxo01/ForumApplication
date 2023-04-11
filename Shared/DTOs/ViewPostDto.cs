namespace Shared.DTOs;

public class ViewPostDto
{
    public int ForumId { get; set; }
    public int PostId { get; set; }

    public ViewPostDto(int forumId, int postId)
    {
        ForumId = forumId;
        PostId = postId;
    }
}