using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Superheroes.Queries.GetHeroesWithPagination;

public class GetSuperheroQuery : IRequest<SuperheroDto>
{
    public int Id { get; set; }
}

public class GetSuperheroQueryHandler : IRequestHandler<GetSuperheroQuery, SuperheroDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSuperheroQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<SuperheroDto> Handle(GetSuperheroQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Superheroes.FindAsync(request.Id);

        return _mapper.Map<Superhero, SuperheroDto>(entity!);
    }
}

