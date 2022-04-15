using Application.Common.Mappings;
using Domain.Entities;

namespace Application.SuperHeroes.Queries.GetHeroesWithPagination;

public class PublisherDto : IMapFrom<Publisher>
{
    public int Id { get; set; }
    public string? PublisherName { get; set; }
}