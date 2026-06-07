using DailyManager.Core.Entities;

namespace DailyManager.Core.Interfaces;

public interface ITaskRepository
{
    Task<UserTask?> GetByTitle(string title);
}
