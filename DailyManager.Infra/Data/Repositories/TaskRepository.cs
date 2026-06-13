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

    public async Task<UserTask?> GetByTitle(string title)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Title == title);
    }

    public async Task AddTaskAsync(UserTask task)
    {
        await _context.AddAsync(task);
        await _context.SaveChangesAsync();
    }
}
