using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Attribute> Attributes { get; }
    DbSet<HeroAttribute> HeroAttributes { get; }
    DbSet<HeroPower> HeroPowers { get; }
    DbSet<Publisher> Publishers { get; }
    DbSet<Race> Races { get; }
    DbSet<Superhero> Superheroes { get; }
    DbSet<Superpower> Superpowers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}