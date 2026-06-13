using DailyManager.Application.DTOs;
using DailyManager.Application.DTOs.Task;
using DailyManager.Core.Entities;

namespace DailyManager.Application.Interfaces;

public interface ITaskService
{
    Task<ResultDto<UserTask>> GetByTitle(string title);
    Task<ResultDto<UserTask>> AddTaskAsync(TaskRequestDto task, Guid userId);
}
