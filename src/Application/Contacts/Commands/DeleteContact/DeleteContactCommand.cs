using MediatR;

namespace Application.Contacts.Commands.DeleteContact;

public record DeleteContactCommand(
    Guid Id,
    Guid UserId) : IRequest<Unit>;
