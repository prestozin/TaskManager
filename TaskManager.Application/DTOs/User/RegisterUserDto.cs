namespace TaskManager.Application.DTOs;

public class RegisterUserDto : AuthBaseDto
{
    public string Name { get; set; } = string.Empty;
}
