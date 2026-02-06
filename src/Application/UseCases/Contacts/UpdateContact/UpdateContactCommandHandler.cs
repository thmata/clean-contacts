using Application.Common.IntegrationEvents;
using Application.Interfaces;
using MassTransit;
using MediatR;

namespace Application.UseCases.Contacts.UpdateContact;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactResponse>
{
    private readonly IContactRepository _contactRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public UpdateContactCommandHandler(
        IContactRepository contactRepository,
        IPublishEndpoint publishEndpoint)
    {
        _contactRepository = contactRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<UpdateContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

        if (contact is null)
            throw new KeyNotFoundException($"Contato com Id {request.Id} n�o encontrado.");

        if (contact.UserId != request.UserId)
            throw new UnauthorizedAccessException("Voc� n�o tem permiss�o para atualizar este contato.");

        contact.Update(request.Name, request.Email, request.Phone);

        await _contactRepository.UpdateAsync(contact, cancellationToken);

        await _publishEndpoint.Publish(new ContactUpdatedEvent(
            contact.Id,
            contact.UserId,
            contact.Name,
            contact.Email,
            contact.Phone,
            DateTime.UtcNow
        ), cancellationToken);

        return new UpdateContactResponse(
            contact.Id,
            contact.UserId,
            contact.Name,
            contact.Email,
            contact.Phone,
            contact.UpdatedAt!.Value);
    }
}
