using MediatR;

namespace Application.UseCases.Contacts.GetContactById;

public record GetContactByIdQuery(
    Guid Id,
    Guid UserId) : IRequest<GetContactByIdResponse>;
