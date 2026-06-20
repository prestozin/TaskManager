using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Application.DTOs.Task;
using TaskManager.Application.Interfaces;
using TaskManager.Core.Entities;
using TaskManager.Core.Shared;

namespace TaskManager.Api.Controllers;

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
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.GetTasksByTitle(title, userId);

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

    [Authorize]
    [HttpGet("Add")]
    public async Task<IActionResult> GetAllTasks([FromQuery]PagedParamsDto pagedParams )
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.GetAllTasks(userId, pagedParams);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}

