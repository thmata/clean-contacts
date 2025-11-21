using MediatR;

namespace Application.Contacts.Commands.CreateContact;

public record CreateContactCommand(
    Guid UserId,
    string Name,
    string Email,
    string Phone) : IRequest<CreateContactResponse>;
