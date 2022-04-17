using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Superheroes.Queries.GetHeroesWithPagination;

public class RaceDto : IMapFrom<Race>
{
    public int Id { get; set; }
    public string? RaceName { get; set; }
}