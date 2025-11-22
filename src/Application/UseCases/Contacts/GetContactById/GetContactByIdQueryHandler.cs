using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Contacts.GetContactById;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdResponse>
{
    private readonly IContactRepository _contactRepository;

    public GetContactByIdQueryHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<GetContactByIdResponse> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetByIdAsync(request.Id, cancellationToken);

        if (contact is null)
            throw new KeyNotFoundException($"Contato com Id {request.Id} não encontrado.");

        if (contact.UserId != request.UserId)
            throw new UnauthorizedAccessException("Você não tem permissão para acessar este contato.");

        return new GetContactByIdResponse(
            contact.Id,
            contact.Name,
            contact.Email,
            contact.Phone,
            contact.CreatedAt,
            contact.UpdatedAt);
    }
}
