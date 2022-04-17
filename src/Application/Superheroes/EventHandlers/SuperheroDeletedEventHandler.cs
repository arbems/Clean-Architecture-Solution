using Application.Common.Models;
using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Superheroes.EventHandlers;

public class SuperheroDeletedEventHandler : INotificationHandler<DomainEventNotification<SuperheroDeletedEvent>>
{
    private readonly ILogger<SuperheroDeletedEventHandler> _logger;

    public SuperheroDeletedEventHandler(ILogger<SuperheroDeletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<SuperheroDeletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}