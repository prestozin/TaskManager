using DailyManager.Core.Entities;

namespace DailyManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<List<UserTask>> GetByTitle(string title, Guid userId);
    Task AddTaskAsync(UserTask task);
}
