using MediatR;

namespace Application.Contacts.Commands.UpdateContact;

public record UpdateContactCommand(
    Guid Id,
    Guid UserId,
    string Name,
    string Email,
    string Phone) : IRequest<UpdateContactResponse>;
