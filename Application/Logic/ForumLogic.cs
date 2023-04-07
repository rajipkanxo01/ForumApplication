using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class ForumLogic : IForumLogic
{
    private readonly IForumDao forumDao;

    public ForumLogic(IForumDao forumDao)
    {
        this.forumDao = forumDao;
    }

    public async Task<Forum?> CreateAsync(ForumDto forumDto)
    {
        Forum? forum = new Forum
        {
            CreatedBy = forumDto.CreatedBy,
            ForumName = forumDto.ForumTitle,
            ForumDescription = forumDto.ForumDescription
        };
        Forum? createdForum = await forumDao.CreateAsync(forum);
        return createdForum;
    }

    public Task<IEnumerable<Forum?>> GetAsync()
    {
        return forumDao.GetAllForumsAsync();
    }

    public Task<Forum?> GetForumByIdAsync(int id)
    {
        return forumDao.GetForumByIdAsync(id);
    }
}