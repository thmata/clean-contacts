using FluentValidation;

namespace Application.Contacts.Commands.UpdateContact;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório.");

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
            .Must(BeValidPhone).WithMessage("Telefone deve ter entre 10 e 15 dígitos.");
    }

    private static bool BeValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        var digitsOnly = new string(phone.Where(char.IsDigit).ToArray());
        return digitsOnly.Length >= 10 && digitsOnly.Length <= 15;
    }
}
