using Application.LogicInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ForumController : ControllerBase
{
    private readonly IForumLogic forumLogic;

    public ForumController(IForumLogic forumLogic)
    {
        this.forumLogic = forumLogic;
    }

    [HttpPost, Route("create"), Authorize]
    public async Task<ActionResult<Forum>> CreateAsync(ForumDto forumDto)
    {
        try
        {
            Forum? forum = await forumLogic.CreateAsync(forumDto);
            return Created($"/forum/{forum.ForumId}", forum);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}