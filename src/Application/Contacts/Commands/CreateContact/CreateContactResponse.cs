namespace Application.Contacts.Commands.CreateContact;

public record CreateContactResponse(
    Guid Id,
    Guid UserId,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt);
