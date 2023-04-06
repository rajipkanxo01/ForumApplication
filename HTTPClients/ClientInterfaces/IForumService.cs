using Shared.DTOs;
using Shared.Models;

namespace HTTPClients.ClientInterfaces;

public interface IForumService
{
    Task<Forum> CreateAsync(ForumDto dto);
}