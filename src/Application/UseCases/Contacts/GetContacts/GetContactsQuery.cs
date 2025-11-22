using MediatR;

namespace Application.UseCases.Contacts.GetContacts;

public record GetContactsQuery(Guid UserId) : IRequest<GetContactsResponse>;
