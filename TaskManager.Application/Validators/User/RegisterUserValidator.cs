using FluentValidation;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Validators.User;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty()
                .WithMessage("O nome é obrigatório.")
          .MinimumLength(3)
                .WithMessage("O nome deve possuir pelo menos 3 caracteres.")
          .MaximumLength(100)
                .WithMessage("O nome não pode exceder 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
            .EmailAddress()
                .WithMessage("Informe um e-mail válido.")
            .MaximumLength(255)
                .WithMessage("O e-mail não pode exceder 255 caracteres.");

        RuleFor(x => x.Password)
            .NotEmpty()
                .WithMessage("A senha é obrigatória.")
            .MinimumLength(8)
                .WithMessage("A senha deve possuir pelo menos 8 caracteres.")
            .MaximumLength(100)
                .WithMessage("A senha não pode exceder 100 caracteres.")
            .Matches("[A-Z]")
                .WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
            .Matches("[a-z]")
                .WithMessage("A senha deve conter pelo menos uma letra minúscula.")
            .Matches("[0-9]")
                .WithMessage("A senha deve conter pelo menos um número.")
            .Matches("[^a-zA-Z0-9]")
                .WithMessage("A senha deve conter pelo menos um caractere especial.");
    }
}
