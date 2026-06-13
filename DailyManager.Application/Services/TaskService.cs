using DailyManager.Application.DTOs;
using DailyManager.Application.DTOs.Task;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;
using Mapster;
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

    public async Task<ResultDto<UserTask>> AddTaskAsync(TaskRequestDto task, Guid userId)
    {
        if (task == null || userId == Guid.Empty)
            return ResultDto<UserTask>.Failure(string.Format("Falha ao criar tarefa"));

        UserTask newTask = task.Adapt<UserTask>();
        newTask.UserId = userId;

        await _taskRepository.AddTaskAsync(newTask);
        return ResultDto<UserTask>.Success(string.Format("Tarefa criada com sucesso"));
    }
}

