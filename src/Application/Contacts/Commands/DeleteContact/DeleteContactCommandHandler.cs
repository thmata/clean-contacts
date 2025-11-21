using Application.Common.Interfaces;
using MediatR;

namespace Application.Contacts.Commands.DeleteContact;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
{
    private readonly IContactRepository _contactRepository;

    public DeleteContactCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

        if (contact is null)
            throw new KeyNotFoundException($"Contato com Id {request.Id} não encontrado.");

        if (contact.UserId != request.UserId)
            throw new UnauthorizedAccessException("Você não tem permissão para excluir este contato.");

        await _contactRepository.DeleteAsync(contact, cancellationToken);

        return Unit.Value;
    }
}
