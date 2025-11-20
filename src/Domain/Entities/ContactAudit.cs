namespace Domain.Entities;

public class ContactAudit : BaseEntity
{
    public Guid ContactId { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    private ContactAudit() { }

    public ContactAudit(Guid contactId, Guid userId, string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome não pode ser vazio.", nameof(name));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email não pode ser vazio.", nameof(email));

        ContactId = contactId;
        UserId = userId;
        Name = name;
        Email = email;
    }

}
