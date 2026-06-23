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
    [HttpGet("Id")]
    public async Task<IActionResult> GetById(Guid taskId)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.GetTaskById(taskId, userId);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [Authorize]
    [HttpGet("Title")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.GetTasksByTitle(title, userId);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [Authorize]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllTasks([FromQuery] PagedParamsDto pagedParams)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.GetAllTasks(userId, pagedParams);

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
    [HttpPut("Edit")]
    public async Task<IActionResult> EditTask(TaskEditDto dto)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.EditTaskAsync(dto, userId);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [Authorize]
    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteTask(Guid taskId)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _taskService.DeleteTaskAsync(taskId, userId);

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}

