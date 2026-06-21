using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.Task;
using TaskManager.Core.Entities;
using TaskManager.Core.Shared;

namespace TaskManager.Application.Interfaces;

public interface ITaskService
{
    Task<ResultDto<List<TaskResponseDto>>> GetTasksByTitle(string title, Guid userId);
    Task<ResultDto<TaskItem>> AddTaskAsync(TaskRequestDto task, Guid userId);
    Task<ResultDto<PagedResultDto<TaskResponseDto>>> GetAllTasks(Guid userId, PagedParamsDto pagedParams);
}
