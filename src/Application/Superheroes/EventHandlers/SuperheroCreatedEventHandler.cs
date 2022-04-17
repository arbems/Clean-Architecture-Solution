using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Superheroes.EventHandlers;

public class SuperheroCreatedEventHandler : INotificationHandler<DomainEventNotification<SuperheroCreatedEvent>>
{
    private readonly ILogger<SuperheroCreatedEventHandler> _logger;

    public SuperheroCreatedEventHandler(ILogger<SuperheroCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<SuperheroCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}