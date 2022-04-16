using Application.Common.Models;
using Application.SuperHeroes.Commands.CreateHero;
using Application.SuperHeroes.Commands.DeleteHero;
using Application.SuperHeroes.Commands.UpdateHero;
using Application.SuperHeroes.Queries.GetHeroesWithPagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PublicAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ApiControllerBase
{
    private readonly ILogger<HeroesController> _logger;

    public HeroesController(ILogger<HeroesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<SuperheroDto>>> GetHeroesWithPagination([FromQuery] GetHeroesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
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
        await Mediator.Send(new DeleteHeroCommand { Id = id });

        return NoContent();
    }
}

