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
    public async Task<IActionResult> Register(RegisterDto dto)
    {
       var result = await _userService.RegisterAsync(dto);

        if(!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _userService.LoginAsync(dto);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}
