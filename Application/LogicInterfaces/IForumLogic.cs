using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IForumLogic
{
    Task<Forum?> CreateAsync(ForumDto forumDto);
}