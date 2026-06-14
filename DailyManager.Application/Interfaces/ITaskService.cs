using DailyManager.Application.DTOs;
using DailyManager.Application.DTOs.Task;
using DailyManager.Core.Entities;

namespace DailyManager.Application.Interfaces;

public interface ITaskService
{
    Task<ResultDto<List<TaskResponseDto>>> GetTasksByTitle(string title, Guid userId);
    Task<ResultDto<UserTask>> AddTaskAsync(TaskRequestDto task, Guid userId);
}
