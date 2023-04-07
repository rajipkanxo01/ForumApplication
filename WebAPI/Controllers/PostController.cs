using Application.LogicInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost, Route("create"), Authorize]
    public async Task<ActionResult<Post>> CreateAsync(PostDto postDto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(postDto);
            return Created($"/post/{post.PostId}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllPostByForumId([FromRoute] int id)
    {
        try
        {
            IEnumerable<Post> allPosts = await postLogic.GetPostByForumAsync(id);
            return Ok(allPosts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}