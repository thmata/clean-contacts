using MediatR;

namespace Application.UseCases.Contacts.GetContacts;

public record GetContactsQuery(
    Guid UserId,
    int Page = 1,
    int PageSize = 10) : IRequest<GetContactsResponse>;
