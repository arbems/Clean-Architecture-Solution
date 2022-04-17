using Application.Common.Mappings;

namespace Application.Superheroes.Queries.GetHeroesWithPagination;

public class AttributeDto : IMapFrom<Domain.Entities.Attribute>
{
    public int Id { get; set; }
    public string? AttributeName { get; set; }
}
