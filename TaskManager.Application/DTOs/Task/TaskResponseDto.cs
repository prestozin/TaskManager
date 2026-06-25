namespace TaskManager.Application.DTOs;

public class TaskResponseDto : TaskBaseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Status { get; set; }
}
