using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Superheroes.Queries.GetHeroesWithPagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Superheroes.Queries.GetHeroesWithPagination;

public class GetSuperheroesWithPaginationQuery : IRequest<PaginatedList<SuperheroDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetSuperheroesWithPaginationQueryHandler : IRequestHandler<GetSuperheroesWithPaginationQuery, PaginatedList<SuperheroDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSuperheroesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SuperheroDto>> Handle(GetSuperheroesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Superheroes.AsNoTracking()
            .OrderBy(x => x.SuperheroName)
            .ProjectTo<SuperheroDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
