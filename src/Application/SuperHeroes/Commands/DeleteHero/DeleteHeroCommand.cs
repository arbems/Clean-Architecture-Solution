using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.SuperHeroes.Commands.DeleteHero;

public class DeleteHeroCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteHeroCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Superheroes
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Superhero), request.Id);
        }

        _context.Superheroes.Remove(entity);

        // TODO:
        //entity.DomainEvents.Add(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}