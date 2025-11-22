namespace Application.UseCases.Contacts.GetContactById;

public record GetContactByIdResponse(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
