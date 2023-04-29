using Application.DAOInterfaces;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace Application.Logic;

public class ForumLogic : IForumLogic
{
    private readonly IForumDao forumDao;
    private readonly IUserDao userDao;

    public ForumLogic(IForumDao forumDao, IUserDao userDao)
    {
        this.forumDao = forumDao;
        this.userDao = userDao;
    }

    public async Task<Forum?> CreateAsync(ForumDto forumDto)
    {
        User? user = await userDao.GetByUsernameAsync(forumDto.CreatedBy);
        Forum? forum = new Forum(user, forumDto.ForumTitle, forumDto.ForumDescription);


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

    public Task<IEnumerable<Post>> GetAllPostsAsync(int id)
    {
        return forumDao.GetAllPostsOfForum(id);
    }
}