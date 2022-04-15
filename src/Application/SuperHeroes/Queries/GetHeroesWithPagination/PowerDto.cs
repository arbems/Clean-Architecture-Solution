using Application.Common.Mappings;
using Domain.Entities;

namespace Application.SuperHeroes.Queries.GetHeroesWithPagination;

public class PowerDto : IMapFrom<Power>
{
    public int Id { get; set; }
    public string PowerName { get; set; }
}