using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Superhero : AuditableEntity, IHasDomainEvent
{
    public int Id { get; set; }
    public string SuperheroName { get; set; } = String.Empty;
    public string? FullName { get; set; }
    public int? HeightCm { get; set; }
    public int? WeightKg { get; set; }

    public Colour? EyeColour { get; set; } = Colour.NoColour;
    public Colour? HairColour { get; set; } = Colour.NoColour;
    public Colour? SkinColour { get; set; } = Colour.NoColour;
    public Alignment? Alignment { get; set; } = Alignment.NA;
    public Gender? Gender { get; set; } = Gender.NA;

    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public int? RaceId { get; set; }
    public Race? Race { get; set; }

    public IList<Attribute> Attributes { get; set; } = new List<Attribute>();
    public IList<Power> Powers { get; set; } = new List<Power>();

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}