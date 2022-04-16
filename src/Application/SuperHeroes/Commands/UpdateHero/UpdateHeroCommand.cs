using Application.Common.Interfaces;
using MediatR;
using Application.Common.Exceptions;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.SuperHeroes.Commands.UpdateHero;

public class UpdateHeroCommand : IRequest
{
    public int Id { get; set; }
    public string SuperheroName { get; set; } = String.Empty;
    public string FullName { get; set; } = String.Empty;
    public int? HeightCm { get; set; }
    public int? WeightKg { get; set; }

    public string? EyeColour { get; set; }
    public string? HairColour { get; set; }
    public string? SkinColour { get; set; }
    public string? Alignment { get; set; }
    public string? Gender { get; set; }

    public int PublisherId { get; set; }

    public int RaceId { get; set; }

    public List<int> Attributes { get; set; } = new();
    public List<int> Powers { get; set; } = new();
}

public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateHeroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Superheroes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Superhero), request.Id);
        }

        entity.SuperheroName = request.SuperheroName;
        entity.FullName = request.FullName;
        entity.HeightCm = request.HeightCm;
        entity.WeightKg = request.WeightKg;
        entity.EyeColour = string.IsNullOrEmpty(request.EyeColour) ? Colour.NoColour : Colour.From(request.EyeColour);
        entity.HairColour = string.IsNullOrEmpty(request.HairColour) ? Colour.NoColour : Colour.From(request.HairColour);
        entity.SkinColour = string.IsNullOrEmpty(request.SkinColour) ? Colour.NoColour : Colour.From(request.SkinColour);
        entity.Alignment = string.IsNullOrEmpty(request.Alignment) ? Alignment.NA : Alignment.From(request.Alignment);
        entity.Gender = string.IsNullOrEmpty(request.Gender) ? Gender.NA : Gender.From(request.Gender);
        entity.Publisher = _context.Publishers.FindAsync(request.PublisherId).Result;
        entity.Race = _context.Races.FindAsync(request.RaceId).Result;
        entity.Attributes = _context.Attributes.Where(a => request.Attributes.Contains(a.Id)).ToList();
        entity.Powers = _context.Powers.Where(a => request.Powers.Contains(a.Id)).ToList();

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

