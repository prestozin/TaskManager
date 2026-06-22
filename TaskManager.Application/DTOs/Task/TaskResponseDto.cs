using TaskManager.Core.Entities;

namespace TaskManager.Application.DTOs.Task;

public class TaskResponseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Status { get; set; }
}
