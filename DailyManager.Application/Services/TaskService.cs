using DailyManager.Application.DTOs;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DailyManager.Application.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<ResultDto<UserTask>> GetByTitle(string title)
    {
        var task = await _taskRepository.GetByTitle(title);

        if (task == null)
            return ResultDto<UserTask>.Failure(string.Format("Tarefa não encontrada"));

        return ResultDto<UserTask>.Success(string.Format("Tarefa encontrada"));
    }
}

