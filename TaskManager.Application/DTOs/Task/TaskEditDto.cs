namespace TaskManager.Application.DTOs.Task;

public class TaskEditDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? StatusId { get; set; }
}
