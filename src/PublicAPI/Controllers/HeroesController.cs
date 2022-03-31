using Application.Common.Models;
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
    public async Task<ActionResult<PaginatedList<SuperHeroBriefDto>>> GetHeroesWithPagination([FromQuery] GetHeroesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}

