using Application.Common.Models;
using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Contacts.GetContacts;

public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, GetContactsResponse>
{
    private readonly IContactRepository _contactRepository;

    public GetContactsQueryHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<GetContactsResponse> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        var (contacts, totalCount) = await _contactRepository.GetByUserIdPagedAsync(
            request.UserId, 
            request.Page, 
            request.PageSize, 
            cancellationToken);

        var contactDtos = contacts.Select(c => new ContactDto(
            c.Id,
            c.Name,
            c.Email,
            c.Phone,
            c.CreatedAt,
            c.UpdatedAt)).ToList();

        var pagedResult = new PagedResult<ContactDto>(
            contactDtos,
            request.Page,
            request.PageSize,
            totalCount);

        return new GetContactsResponse(pagedResult);
    }
}
