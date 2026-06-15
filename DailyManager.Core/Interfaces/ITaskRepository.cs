using DailyManager.Core.Entities;
using DailyManager.Core.Shared;

namespace DailyManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<List<UserTask>> GetByTitle(string title, Guid userId);
    Task AddTaskAsync(UserTask task);
    Task<(IEnumerable<UserTask> tasks, int totalCount)> GetAllTasks(Guid userId, PagedParamsDto pagedParams);
}
