using TaskManager.Core.Entities;
using TaskManager.Core.Shared;

namespace TaskManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetTaskByTitle(string title, Guid userId);
    Task AddTaskAsync(TaskItem task);
    Task<(IEnumerable<TaskItem> tasks, int totalCount)> GetAllTasks(Guid userId, PagedParamsDto pagedParams);
    Task<TaskItem> GetTaskById(Guid? taskId, Guid userId);
    Task EditTaskAsync(TaskItem task);
    Task<bool> DeleteTaskAsync(TaskItem task);
}
