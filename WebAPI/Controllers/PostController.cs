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
    public async Task<ActionResult<Post>> CreateAsync(CreatePostDto createPostDto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(createPostDto);
            return Created($"/post/{post.PostId}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("forum/{id:int}")]
    public async Task<ActionResult<IEnumerable<Post>>> GetAllPostByForumId([FromRoute] int id)
    {
        try
        {
            IEnumerable<Post> allPosts = await postLogic.GetAllPostsByForumIdAsync(id);
            return Ok(allPosts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("viewpost/")]
    public async Task<ActionResult<Post>> GetPostById([FromQuery] int forumId, [FromQuery] int postId)
    {
        try
        {
            Post? post = await postLogic.GetPostByIdAsync(forumId,postId);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
}