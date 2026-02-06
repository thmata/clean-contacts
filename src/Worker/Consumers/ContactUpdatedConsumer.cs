using Application.Common.IntegrationEvents;
using Domain.Entities;
using Infrastructure.Persistence;
using MassTransit;

namespace Worker.Consumers;

public class ContactUpdatedConsumer : IConsumer<ContactUpdatedEvent>
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ContactUpdatedConsumer> _logger;

    public ContactUpdatedConsumer(ApplicationDbContext context, ILogger<ContactUpdatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ContactUpdatedEvent> context)
    {
        var message = context.Message;
        
        _logger.LogInformation("Processing ContactUpdatedEvent for ContactId: {ContactId}", message.ContactId);

        var audit = new ContactAudit(
            message.ContactId,
            message.UserId,
            message.Name,
            message.Email
        );

        await _context.ContactAudits.AddAsync(audit);
        await _context.SaveChangesAsync();
        
        _logger.LogInformation("Successfully audited update for ContactId: {ContactId}", message.ContactId);
    }
}
