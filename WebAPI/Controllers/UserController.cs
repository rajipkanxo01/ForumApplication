using Application.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    [HttpGet]
    public async Task<ActionResult<User>> CreateAsync(UserDto userDto)
    {
        try
        {
            User user = await userLogic.CreateAsync(userDto);
            return Created($"/user/{user.UserId}", user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}