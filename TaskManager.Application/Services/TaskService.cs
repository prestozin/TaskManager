using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.Task;
using TaskManager.Application.Interfaces;
using Mapster;
using TaskManager.Core.Interfaces;
using TaskManager.Core.Entities;
using TaskManager.Core.Shared;

namespace TaskManager.Application.Services;
public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<ResultDto<List<TaskResponseDto>>> GetTasksByTitle(string title, Guid userId)
    {
        List<TaskItem> tasks = await _taskRepository.GetByTitle(title, userId);

        if (tasks.Count == 0)
            return ResultDto<List<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        List<TaskResponseDto> listOfTasks = tasks.Adapt<List<TaskResponseDto>>();

        return ResultDto<List<TaskResponseDto>>.Success(listOfTasks);
    }

    public async Task<ResultDto<TaskItem>> AddTaskAsync(TaskRequestDto task, Guid userId)
    {
        if (task == null || userId == Guid.Empty)
            return ResultDto<TaskItem>.Failure(string.Format("Falha ao criar tarefa"));

        TaskItem newTask = task.Adapt<TaskItem>();
        newTask.UserId = userId;

        await _taskRepository.AddTaskAsync(newTask);
        return ResultDto<TaskItem>.Success(string.Format("Tarefa criada com sucesso"));
    }

    public async Task<ResultDto<PagedResultDto<TaskResponseDto>>> GetAllTasks(Guid userId, PagedParamsDto pagedParams)
    {
        if (userId == Guid.Empty || pagedParams == null )
            return ResultDto<PagedResultDto<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        var (tasks, totalCount) = await _taskRepository.GetAllTasks(userId, pagedParams);

        List<TaskResponseDto> tasksDtos = tasks.Adapt<List<TaskResponseDto>>();
        
        if (tasksDtos.Count == 0)
            return ResultDto<PagedResultDto<TaskResponseDto>>.Failure(string.Format("Nenhuma tarefa encontrada"));

        PagedResultDto<TaskResponseDto> pagedResult = new PagedResultDto<TaskResponseDto>(tasksDtos, pagedParams.PageNumber, pagedParams.PageSize, totalCount);

        return ResultDto<PagedResultDto<TaskResponseDto>>.Success(pagedResult);
    }
}

