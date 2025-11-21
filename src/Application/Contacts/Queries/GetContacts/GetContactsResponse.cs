namespace Application.Contacts.Queries.GetContacts;

public record GetContactsResponse(IEnumerable<ContactDto> Contacts);

public record ContactDto(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
