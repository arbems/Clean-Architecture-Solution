using Domain.Common;

namespace Domain.Entities;

public class Power : AuditableEntity
{
    public int Id { get; set; }
    public string PowerName { get; set; }

    public IList<Superhero> Heroes { get; set; } = new List<Superhero>();
}