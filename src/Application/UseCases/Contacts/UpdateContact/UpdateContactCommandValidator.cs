using FluentValidation;

namespace Application.UseCases.Contacts.UpdateContact;

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
            .Must(BeValidBrazilianPhone).WithMessage("Telefone inválido. Deve conter apenas números (10 ou 11 dígitos com DDD).")
            .Matches(@"^\d{10,11}$").WithMessage("Telefone deve conter apenas números (DDD + número).");
    }

    private static bool BeValidBrazilianPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        var digitsOnly = new string(phone.Where(char.IsDigit).ToArray());

        if (digitsOnly.Length < 10 || digitsOnly.Length > 11)
            return false;

        if (digitsOnly.Length >= 2)
        {
            if (!int.TryParse(digitsOnly.Substring(0, 2), out var ddd))
                return false;

            if (ddd < 11 || ddd > 99)
                return false;
        }

        return true;
    }
}
