using Microsoft.AspNetCore.Mvc;

namespace PublicAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private readonly ILogger<HeroesController> _logger;

    public HeroesController(ILogger<HeroesController> logger)
    {
        _logger = logger;
    }

}

