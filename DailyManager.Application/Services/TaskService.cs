using DailyManager.Application.DTOs;
using DailyManager.Application.DTOs.Task;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;
using DailyManager.Core.Shared;
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
    public async Task<ResultDto<List<TaskResponseDto>>> GetTasksByTitle(string title, Guid userId)
    {
        List<UserTask> tasks = await _taskRepository.GetByTitle(title, userId);

        if (!tasks.Any())
            return ResultDto<List<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        List<TaskResponseDto> listOfTaks = tasks.Adapt<List<TaskResponseDto>>();

        return ResultDto<List<TaskResponseDto>>.Success(listOfTaks);
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

    public async Task<ResultDto<PagedResultDto<TaskResponseDto>>> GetAllTasks(Guid userId, PagedParamsDto pagedParams)
    {
        if (userId == Guid.Empty || pagedParams == null )
            return ResultDto<PagedResultDto<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        var (tasks, totalCount) = await _taskRepository.GetAllTasks(userId, pagedParams);

        var taskDtos = tasks.Adapt<List<TaskResponseDto>>();
        
        if (!taskDtos.Any())
            return ResultDto<PagedResultDto<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        var pagedResult = new PagedResultDto<TaskResponseDto>(taskDtos, pagedParams.PageNumber, pagedParams.PageSize, totalCount);

        return ResultDto<PagedResultDto<TaskResponseDto>>.Success(pagedResult);
    }
}

