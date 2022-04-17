using Application.Common.Models;
using Application.Superheroes.Commands.CreateHero;
using Application.Superheroes.Commands.DeleteHero;
using Application.Superheroes.Commands.UpdateHero;
using Application.Superheroes.Queries.GetHeroesWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace PublicAPI.Controllers;

public class SuperheroesController : ApiControllerBase
{
    private readonly ILogger<SuperheroesController> _logger;

    public SuperheroesController(ILogger<SuperheroesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<SuperheroDto>>> GetSuperheroesWithPagination([FromQuery] GetSuperheroesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SuperheroDto>> GetSuperhero(int id)
    {
        return await Mediator.Send(new GetSuperheroQuery { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromForm] CreateHeroCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateHeroCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteSuperheroCommand { Id = id });

        return NoContent();
    }
}

