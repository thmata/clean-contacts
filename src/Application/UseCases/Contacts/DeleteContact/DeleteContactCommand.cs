using MediatR;

namespace Application.UseCases.Contacts.DeleteContact;

public record DeleteContactCommand(
    Guid Id,
    Guid UserId) : IRequest<Unit>;
