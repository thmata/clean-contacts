namespace Application.Contacts.Commands.UpdateContact;

public record UpdateContactResponse(
    Guid Id,
    Guid UserId,
    string Name,
    string Email,
    string Phone,
    DateTime UpdatedAt);
