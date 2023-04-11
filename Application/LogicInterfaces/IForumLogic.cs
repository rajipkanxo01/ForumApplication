using System.Collections;
using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IForumLogic
{
    Task<Forum?> CreateAsync(ForumDto forumDto);
    Task<IEnumerable<Forum?>> GetAsync();
    Task<Forum?> GetForumByIdAsync(int id);
    Task<IEnumerable<Post>> GetAllPostsAsync(int id);
}