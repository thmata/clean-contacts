namespace Domain.Entities;

public class Contact : BaseEntity
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    
    public User User { get; private set; } = null!;

    private Contact() { }

    public Contact(Guid userId, string name, string email, string phone)
    {
        ValidateName(name);
        ValidateEmail(email);
        ValidatePhone(phone);

        UserId = userId;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public void UpdateName(string name)
    {
        ValidateName(name);
        Name = name;
        MarkAsUpdated();
    }

    public void UpdateEmail(string email)
    {
        ValidateEmail(email);
        Email = email;
        MarkAsUpdated();
    }

    public void UpdatePhone(string phone)
    {
        ValidatePhone(phone);
        Phone = phone;
        MarkAsUpdated();
    }

    public void Update(string name, string email, string phone)
    {
        ValidateName(name);
        ValidateEmail(email);
        ValidatePhone(phone);

        Name = name;
        Email = email;
        Phone = phone;
        MarkAsUpdated();
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome não pode ser vazio.", nameof(name));

        if (name.Length < 2)
            throw new ArgumentException("Nome deve ter no mínimo 2 caracteres.", nameof(name));

        if (name.Length > 100)
            throw new ArgumentException("Nome deve ter no máximo 100 caracteres.", nameof(name));
    }

    private static void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio.", nameof(email));

        if (!email.Contains('@'))
            throw new ArgumentException("Email inválido.", nameof(email));

        if (email.Length > 255)
            throw new ArgumentException("Email deve ter no máximo 255 caracteres.", nameof(email));
    }

    private static void ValidatePhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Telefone não pode ser vazio.", nameof(phone));

        var digitsOnly = new string(phone.Where(char.IsDigit).ToArray());
        
        if (digitsOnly.Length < 10 || digitsOnly.Length > 11)
            throw new ArgumentException("Telefone deve ter 10 ou 11 dígitos (DDD + número).", nameof(phone));

        if (digitsOnly.Length >= 2)
        {
            var ddd = int.Parse(digitsOnly.Substring(0, 2));
            if (ddd < 11 || ddd > 99)
                throw new ArgumentException("DDD inválido. Deve estar entre 11 e 99.", nameof(phone));
        }
    }
}
