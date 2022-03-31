using System.Collections.Generic;

namespace Domain.Entities;

public class Attribute
{
    public int Id { get; set; }
    public string? AttributeName { get; set; }

    public IList<HeroAttribute> Attributes { get; set; } = new List<HeroAttribute>();
}
