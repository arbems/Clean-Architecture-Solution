using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using MediatR;

namespace Application.Superheroes.Commands.DeleteHero;

public class DeleteSuperheroCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteSuperheroCommandHandler : IRequestHandler<DeleteSuperheroCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSuperheroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSuperheroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Superheroes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Superhero), request.Id);
        }

        _context.Superheroes.Remove(entity);

        entity.DomainEvents.Add(new SuperheroDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}