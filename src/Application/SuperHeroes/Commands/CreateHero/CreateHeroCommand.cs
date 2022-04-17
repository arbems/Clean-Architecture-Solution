using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using Domain.ValueObjects;
using MediatR;

namespace Application.Superheroes.Commands.CreateHero;

public class CreateHeroCommand : IRequest<int>
{
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

public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateHeroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
    {
        Superhero entity = new()
        {
            SuperheroName = request.SuperheroName,
            FullName = request.FullName,
            HeightCm = request.HeightCm,
            WeightKg = request.WeightKg,
            EyeColour = string.IsNullOrEmpty(request.EyeColour) ? Colour.NoColour : Colour.From(request.EyeColour),
            HairColour = string.IsNullOrEmpty(request.HairColour) ? Colour.NoColour : Colour.From(request.HairColour),
            SkinColour = string.IsNullOrEmpty(request.SkinColour) ? Colour.NoColour : Colour.From(request.SkinColour),
            Alignment = string.IsNullOrEmpty(request.Alignment) ? Alignment.NA : Alignment.From(request.Alignment),
            Gender = string.IsNullOrEmpty(request.Gender) ? Gender.NA : Gender.From(request.Gender),
            Publisher = _context.Publishers.FindAsync(request.PublisherId).Result,
            Race = _context.Races.FindAsync(request.RaceId).Result,
            Attributes = _context.Attributes.Where(a=> request.Attributes.Contains(a.Id)).ToList(),
            Powers = _context.Powers.Where(a => request.Powers.Contains(a.Id)).ToList()
        };

        entity.DomainEvents.Add(new SuperheroCreatedEvent(entity));

        _context.Superheroes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}