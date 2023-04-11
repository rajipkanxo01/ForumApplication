using Shared.Models;

namespace Shared.DTOs;

public class CreatePostDto
{
    public PostDto? PostDto  { get; set; }
    public int ForumId { get; set; }

    public CreatePostDto(PostDto? postDto, int forumId)
    {
        PostDto = postDto;
        ForumId = forumId;
    }
}