using MediatR;

namespace Application.Contacts.Queries.GetContactById;

public record GetContactByIdQuery(
    Guid Id,
    Guid UserId) : IRequest<GetContactByIdResponse>;
