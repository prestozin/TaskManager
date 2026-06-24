using FluentValidation;
using TaskManager.Application.DTOs;
using TaskManager.Core.Constants;

namespace TaskManager.Application.Validators.User;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty()
                .WithMessage(Messages.NameRequired)
          .Length(Constants.NameMinLength, Constants.NameMaxLength)
                .WithMessage(Messages.NameLength);

        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage(Messages.EmailRequired)
            .EmailAddress()
                .WithMessage(Messages.EmailInvalid)
            .MaximumLength(Constants.EmailMaxLength)
                .WithMessage(Messages.EmailMaxLength);

        RuleFor(x => x.Password)
            .NotEmpty()
                .WithMessage(Messages.PasswordRequired)
           .Matches(Constants.PasswordRegex)
                .WithMessage(Messages.PasswordRules);
    }
}
