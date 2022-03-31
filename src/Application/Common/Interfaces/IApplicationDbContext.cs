using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Domain.Entities.Attribute> Attributes { get; }
    public DbSet<HeroAttribute> HeroAttributes { get; }
    public DbSet<HeroPower> HeroPowers { get; }
    public DbSet<Publisher> Publishers { get; }
    public DbSet<Race> Races { get; }
    public DbSet<Superhero> Superheroes { get; }
    public DbSet<Superpower> Superpowers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
