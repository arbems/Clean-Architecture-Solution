using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class SuperheroCreatedEvent : DomainEvent
{
    public SuperheroCreatedEvent(Superhero item)
    {
        Item = item;
    }

    public Superhero Item { get; }
}