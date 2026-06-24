using FluentValidation;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Validators.User;

public class UserLoginValidator : AbstractValidator<UserLoginDto>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
           .EmailAddress()
                .WithMessage("O e-mail informado é inválido.")
           .MaximumLength(255)
                .WithMessage("O e-mail não pode exceder 255 caracteres."); ;

        RuleFor(x => x.Password)
            .NotEmpty()
                .WithMessage("A senha é obrigatória.")
            .MinimumLength(8)
                .WithMessage("A senha deve possuir pelo menos 8 caracteres.")
            .MaximumLength(100)
                .WithMessage("A senha não pode exceder 100 caracteres.");
    }
}
