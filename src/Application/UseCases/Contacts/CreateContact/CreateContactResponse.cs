namespace Application.UseCases.Contacts.CreateContact;

public record CreateContactResponse(
    Guid Id,
    Guid UserId,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt);
