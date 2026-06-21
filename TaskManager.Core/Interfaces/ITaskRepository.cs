using TaskManager.Core.Entities;
using TaskManager.Core.Shared;

namespace TaskManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetByTitle(string title, Guid userId);
    Task AddTaskAsync(TaskItem task);
    Task<(IEnumerable<TaskItem> tasks, int totalCount)> GetAllTasks(Guid userId, PagedParamsDto pagedParams);
}
