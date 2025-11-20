namespace Domain.Entities;

public class User : BaseEntity
{
    private readonly List<Contact> _contacts = new();

    private User() { }

    public User(string username, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username não pode ser vazio.", nameof(username));
        
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("PasswordHash não pode ser vazio.", nameof(passwordHash));

        Username = username;
        PasswordHash = passwordHash;
    }

    public string Username { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

    public void UpdateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username não pode ser vazio.", nameof(username));

        Username = username;
        MarkAsUpdated();
    }

    public void UpdatePassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("PasswordHash não pode ser vazio.", nameof(passwordHash));

        PasswordHash = passwordHash;
        MarkAsUpdated();
    }

    public Contact AddContact(string name, string email, string phone)
    {
        var contact = new Contact(Id, name, email, phone);
        _contacts.Add(contact);
        return contact;
    }

    public void RemoveContact(Contact contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        if (contact.UserId != Id)
            throw new InvalidOperationException("O contato não pertence a este usuário.");

        _contacts.Remove(contact);
    }
}
