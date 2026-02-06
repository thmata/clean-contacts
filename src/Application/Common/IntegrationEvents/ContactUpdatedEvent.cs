namespace Application.Common.IntegrationEvents;

public record ContactUpdatedEvent(
    Guid ContactId,
    Guid UserId,
    string Name,
    string Email,
    string Phone,
    DateTime OccurredOn
);

