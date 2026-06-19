using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Core.Shared;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infra.Data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;
    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetByTitle(string title, Guid userId)
    {
       return await _context.Tasks
            .Where(t => t.Title != null && t.Title.Contains(title))
            .Where(u => u.UserId == userId)
            .ToListAsync();
    }

    public async Task AddTaskAsync(TaskItem task)
    {
        await _context.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task<(IEnumerable<TaskItem> tasks, int totalCount)> GetAllTasks(Guid userId, PagedParamsDto pagedParams)
    {
        var query = _context.Tasks
            .Where(t => t.UserId == userId);

        int totalCount = await query.CountAsync();

        var tasks = await query
            .OrderByDescending(t => t.CreatedAt)
            .Skip((pagedParams.PageNumber - 1) * pagedParams.PageSize)
            .Take(pagedParams.PageSize)
            .ToListAsync();


        return (query, totalCount);
    }
}
