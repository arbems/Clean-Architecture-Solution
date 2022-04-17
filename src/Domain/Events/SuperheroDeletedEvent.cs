using Domain.Common;
using Domain.Entities;

namespace Domain.Events;

public class SuperheroDeletedEvent : DomainEvent
{
    public SuperheroDeletedEvent(Superhero item)
    {
        Item = item;
    }

    public Superhero Item { get; }
}
