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

    public async Task<List<TaskItem>> GetTaskByTitle(string title, Guid userId)
    {
       return await _context.Tasks
            .Where(t => t.Title != null && t.Title.Contains(title))
            .Where(u => u.UserId == userId)
            .ToListAsync();
    }

    public async Task<TaskItem> GetTaskById(Guid? taskId, Guid userId)
    {
        return await _context.Tasks
            .Include(t => t.Status)
            .SingleOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
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
            .Include(t => t.Status)
            .OrderByDescending(t => t.CreatedAt)
            .Skip((pagedParams.PageNumber - 1) * pagedParams.PageSize)
            .Take(pagedParams.PageSize)
            .ToListAsync();


        return (tasks, totalCount);
    }

    public async Task EditTaskAsync(TaskItem task)
    {
       _context.Update(task);
       await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteTaskAsync(TaskItem task) 
    {
       var taskToDelete =  _context.Remove(task);

       await _context.SaveChangesAsync();

       return taskToDelete != null;
    }
}
