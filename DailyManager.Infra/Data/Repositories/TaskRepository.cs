using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DailyManager.Infra.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserTask>> GetByTitle(string title, Guid userId)
    {
        List<UserTask> tasks = await _context.Tasks
            .Where(t => t.Title != null && t.Title.Contains(title))
            .Where(u => u.UserId == userId)
            .ToListAsync();

        return tasks;
    }

    public async Task AddTaskAsync(UserTask task)
    {
        await _context.AddAsync(task);
        await _context.SaveChangesAsync();
    }
}
