using FluentValidation;

namespace Application.Auth.Commands.AuthenticateUser;

public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
{
    public AuthenticateUserCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username é obrigatório.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password é obrigatório.");
    }
}
