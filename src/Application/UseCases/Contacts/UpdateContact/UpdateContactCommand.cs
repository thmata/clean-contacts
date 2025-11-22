using MediatR;

namespace Application.UseCases.Contacts.UpdateContact;

public record UpdateContactCommand(
    Guid Id,
    Guid UserId,
    string Name,
    string Email,
    string Phone) : IRequest<UpdateContactResponse>;
