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
            ForumName = forumDto.ForumTitle
        };
        ValidateForum(forum);
        Forum? createdForum = await forumDao.CreateAsync(forum);
        return createdForum;
    }

    private void ValidateForum(Forum forum)
    {
        if (string.IsNullOrEmpty(forum.ForumName))
        {
            throw new Exception("Forum Name cannot be empty!!");
        }

        if (string.IsNullOrEmpty(forum.CreatedBy))
        {
            throw new Exception("Created By Username is null!!");
        }
    }
}