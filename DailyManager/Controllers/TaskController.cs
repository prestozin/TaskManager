using DailyManager.Application.DTOs.Task;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DailyManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var result = await _taskService.GetByTitle(title);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [Authorize]
    [HttpPost("Add")]
    public async Task<IActionResult> AddTask(TaskRequestDto task)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.AddTaskAsync(task, userId);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}

