using FluentValidation;
using TaskManager.Application.DTOs;
using TaskManager.Core.Constants;

namespace TaskManager.Application.Validators.Task;

public class BaseTaskValidator<T> : AbstractValidator<T> where T : TaskBaseDto
{
    protected void SetupCommonRules()
    {
        RuleFor(x => x.Title)
         .NotEmpty()
             .WithMessage(Messages.TaskTitleRequired)
         .Length(Constants.TaskTitleMinLength, Constants.TaskTitleMaxLength)
             .WithMessage(Messages.TaskTitleLength);

        RuleFor(x => x.Description)
            .MaximumLength(Constants.TaskDescriptionMaxLength)
                  .WithMessage(Messages.TaskDescriptionMaxLength);
    }

    public BaseTaskValidator()
    {
        SetupCommonRules();
    }
}
