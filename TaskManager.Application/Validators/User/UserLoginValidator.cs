using FluentValidation;
using TaskManager.Application.DTOs;
using TaskManager.Core.Constants;

namespace TaskManager.Application.Validators.User;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty()
                .WithMessage(Messages.EmailRequired)
           .EmailAddress()
                .WithMessage(Messages.EmailInvalid)
           .MaximumLength(Constants.EmailMaxLength)
                .WithMessage(string.Format(Messages.EmailMaxLength, Constants.EmailMaxLength));

        RuleFor(x => x.Password)
            .NotEmpty()
                .WithMessage(Messages.PasswordRequired);
    }
}
