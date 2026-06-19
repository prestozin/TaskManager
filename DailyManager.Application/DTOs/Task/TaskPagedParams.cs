
namespace TaskManager.Application.DTOs.Task;

public class TaskPagedParams
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? Title { get; set; }

    public bool? IsCompleted { get; set; }
}
