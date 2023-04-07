using Application.DAOInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOImpls;

public class ForumDao : IForumDao
{
    public readonly FileContext context;

    public ForumDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Forum?> CreateAsync(Forum toCreateForum)
    {
        int forumId = 1;
        if (context.Forums.Any())
        {
            forumId = context.Forums.Max(forum => forum.ForumId);
            forumId++;
        }

        toCreateForum.ForumId = forumId;
        context.Forums.Add(toCreateForum);
        context.SaveChanges();

        return Task.FromResult(toCreateForum)!;
    }

    public Task<IEnumerable<Forum?>> GetAllForumsAsync()
    {
        IEnumerable<Forum> allForums = context.Forums.AsEnumerable();
        return Task.FromResult(allForums)!;
    }

    public Task<Forum?> GetForumByIdAsync(int id)
    {
        Forum? existingForum = context.Forums.FirstOrDefault(forum => forum.ForumId == id);
        return Task.FromResult(existingForum);
    }
}