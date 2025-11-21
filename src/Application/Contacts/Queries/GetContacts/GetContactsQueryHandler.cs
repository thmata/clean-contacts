using Application.Common.Interfaces;
using MediatR;

namespace Application.Contacts.Queries.GetContacts;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, GetContactsResponse>
{
    private readonly IContactRepository _contactRepository;

    public GetContactsQueryHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<GetContactsResponse> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetByUserIdAsync(request.UserId, cancellationToken);

        var contactDtos = contacts.Select(c => new ContactDto(
            c.Id,
            c.Name,
            c.Email,
            c.Phone,
            c.CreatedAt,
            c.UpdatedAt)).ToList();

        return new GetContactsResponse(contactDtos);
    }
}
