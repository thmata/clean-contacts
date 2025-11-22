using MediatR;

namespace Application.UseCases.Contacts.CreateContact;

public record CreateContactCommand(
    Guid UserId,
    string Name,
    string Email,
    string Phone) : IRequest<CreateContactResponse>;
