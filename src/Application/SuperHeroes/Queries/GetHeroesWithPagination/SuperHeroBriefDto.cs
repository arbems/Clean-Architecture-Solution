using Application.Common.Mappings;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.SuperHeroes.Queries.GetHeroesWithPagination;

public class SuperHeroBriefDto : IMapFrom<Superhero>
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

    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public int? RaceId { get; set; }
    public Race? Race { get; set; }

    //public IList<HeroAttribute> Attributes { get; set; } = new List<HeroAttribute>();
    //public IList<HeroPower> Powers { get; set; } = new List<HeroPower>();
}
