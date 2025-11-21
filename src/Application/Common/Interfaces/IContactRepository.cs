using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IContactRepository
{
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Contact>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Contact> AddAsync(Contact contact, CancellationToken cancellationToken = default);
    Task UpdateAsync(Contact contact, CancellationToken cancellationToken = default);
    Task DeleteAsync(Contact contact, CancellationToken cancellationToken = default);
}
