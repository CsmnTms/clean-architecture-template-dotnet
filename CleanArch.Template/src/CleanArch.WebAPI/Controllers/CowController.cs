using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Controllers;

[Route("cows")]
public class CowController(ILogger<CowController> logger) : ControllerBase
{
    public async Task<IActionResult> GetCowById(int id)
    {
        throw new NotImplementedException();
    }
}
