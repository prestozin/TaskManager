namespace TaskManager.Application.DTOs;

public class TaskResponseDto : TaskBaseDto
{
    public DateTime CreatedAt { get; set; }
    public string? Status { get; set; }
}
