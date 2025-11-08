using CleanArch.UseCases.Cows;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Goats;

[Tags("goats")]
[ApiController]
[Route("goats")]
public partial class GoatController(ICowService _goatService, ILogger<GoatController> _logger) : ControllerBase
{
}
