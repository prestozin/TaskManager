
namespace TaskManager.Application.DTOs;

public class TaskPagedParams
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public string? Title { get; set; }
}
