using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities;

public class Attribute : AuditableEntity
{
    public int Id { get; set; }
    public string? AttributeName { get; set; }

    public IList<Superhero> Heroes { get; set; } = new List<Superhero>();
}
