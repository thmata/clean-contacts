using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Contacts.Commands.CreateContact;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
{
    private readonly IContactRepository _contactRepository;

    public CreateContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact(request.UserId, request.Name, request.Email, request.Phone);

        await _contactRepository.AddAsync(contact, cancellationToken);

        return new CreateContactResponse(
            contact.Id,
            contact.UserId,
            contact.Name,
            contact.Email,
            contact.Phone,
            contact.CreatedAt);
    }
}
