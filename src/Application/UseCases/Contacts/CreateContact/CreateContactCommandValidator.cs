using FluentValidation;

namespace Application.UseCases.Contacts.CreateContact;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MinimumLength(2).WithMessage("Nome deve ter no mínimo 2 caracteres.")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Email inválido.")
            .MaximumLength(255).WithMessage("Email deve ter no máximo 255 caracteres.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Must(BeValidPhone).WithMessage("Telefone deve ter entre 10 e 15 dígitos.")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("Telefone inválido. Deve conter apenas números e opcionalmente o prefixo internacional (+).");
    }

    private static bool BeValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        if (phone.StartsWith("+"))
            phone = phone.Substring(1);

        if (!phone.All(char.IsDigit))
            return false;

 
        return phone.Length >= 10 && phone.Length <= 15;
    }
}
