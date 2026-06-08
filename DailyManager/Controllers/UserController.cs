using DailyManager.Application.DTOs;
using DailyManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterDto dto)
    {
       var result = await _userService.RegisterAsync(dto);

        if(!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpGet("Login")]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var result = await _userService.LoginAsync(dto);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}
