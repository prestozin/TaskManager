using TaskManager.Application.DTOs;
using TaskManager.Application.Validators.Task;


namespace TaskManager.Application.Validators;

public class CreateTaskValidator : BaseTaskValidator<CreateTaskDto>
{
    public CreateTaskValidator()
    {
    }
}
