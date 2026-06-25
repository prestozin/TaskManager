namespace TaskManager.Application.DTOs;

public class CreateUserDto : AuthBaseDto
{
    public string Name { get; set; } = string.Empty;
}
