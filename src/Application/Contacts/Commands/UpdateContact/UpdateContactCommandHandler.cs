using Application.Common.Interfaces;
using MediatR;

namespace Application.Contacts.Commands.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactResponse>
{
    private readonly IContactRepository _contactRepository;

    public UpdateContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<UpdateContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

        if (contact is null)
            throw new KeyNotFoundException($"Contato com Id {request.Id} não encontrado.");

        if (contact.UserId != request.UserId)
            throw new UnauthorizedAccessException("Você não tem permissão para atualizar este contato.");

        contact.Update(request.Name, request.Email, request.Phone);

        await _contactRepository.UpdateAsync(contact, cancellationToken);

        return new UpdateContactResponse(
            contact.Id,
            contact.UserId,
            contact.Name,
            contact.Email,
            contact.Phone,
            contact.UpdatedAt!.Value);
    }
}
