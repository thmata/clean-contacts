using MediatR;

namespace Application.Contacts.Queries.GetContacts;

public record GetContactsQuery(Guid UserId) : IRequest<GetContactsResponse>;
