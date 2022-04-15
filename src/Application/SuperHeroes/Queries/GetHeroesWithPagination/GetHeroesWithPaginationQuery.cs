using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SuperHeroes.Queries.GetHeroesWithPagination;

public class GetHeroesWithPaginationQuery : IRequest<PaginatedList<SuperHeroDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetHeroesWithPaginationQueryHandler : IRequestHandler<GetHeroesWithPaginationQuery, PaginatedList<SuperHeroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetHeroesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SuperHeroDto>> Handle(GetHeroesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Superheroes.AsNoTracking()
            .OrderBy(x => x.SuperheroName)
            .ProjectTo<SuperHeroDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
