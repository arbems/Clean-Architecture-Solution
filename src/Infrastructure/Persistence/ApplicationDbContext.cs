using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IDateTime dateTime,
        IDomainEventService domainEventService) : base(options)
    {
        _dateTime = dateTime;
        _domainEventService = domainEventService;

    }

    public DbSet<Domain.Entities.Attribute> Attributes => Set<Domain.Entities.Attribute>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Race> Races => Set<Race>();
    public DbSet<Superhero> Superheroes => Set<Superhero>();
    public DbSet<Power> Powers => Set<Power>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "UserId";
                    entry.Entity.Created = _dateTime.Now;
                    entry.Entity.RowVersion = Guid.NewGuid();
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = "UserId";
                    entry.Entity.LastModified = _dateTime.Now;
                    entry.Entity.RowVersion = Guid.NewGuid();
                    break;
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = 0;

        try
        {
            result = await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // Update the values of the entity that failed to save from the store (https://docs.microsoft.com/es-es/ef/ef6/saving/concurrency)
            ex.Entries.Single().Reload();
        }

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}
