using DailyManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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


    [HttpGet]
    public async Task<IActionResult> GetByTitle(string title)
    {
       var result = await _taskService.GetByTitle(title);
        
        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }
}

