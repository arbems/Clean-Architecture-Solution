using Application.Common.Mappings;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Superheroes.Queries.GetHeroesWithPagination;

public class SuperheroDto : IMapFrom<Superhero>
{
    public int Id { get; set; }
    public string SuperheroName { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public int? HeightCm { get; set; }
    public int? WeightKg { get; set; }

    public Colour? EyeColour { get; set; } = Colour.NoColour;
    public Colour? HairColour { get; set; } = Colour.NoColour;
    public Colour? SkinColour { get; set; } = Colour.NoColour;
    public Alignment? Alignment { get; set; } = Alignment.NA;
    public Gender? Gender { get; set; } = Gender.NA;

    public PublisherDto? Publisher { get; set; }

    public RaceDto? Race { get; set; }

    public List<AttributeDto> Attributes { get; set; } = new();
    public List<PowerDto> Powers { get; set; } = new();

    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public Guid RowVersion { get; set; }
}
