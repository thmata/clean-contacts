using Application.Common.Models;

namespace Application.UseCases.Contacts.GetContacts;

public record GetContactsResponse(PagedResult<ContactDto> Result);

public record ContactDto(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
