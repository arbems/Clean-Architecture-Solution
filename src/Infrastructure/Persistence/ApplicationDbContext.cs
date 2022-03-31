using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
	}

    public DbSet<Domain.Entities.Attribute> Attributes => Set<Domain.Entities.Attribute>();
    public DbSet<HeroAttribute> HeroAttributes => Set<HeroAttribute>();
    public DbSet<HeroPower> HeroPowers => Set<HeroPower>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<Superhero> Superheroes => Set<Superhero>();
    public DbSet<Superpower> Superpowers => Set<Superpower>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
