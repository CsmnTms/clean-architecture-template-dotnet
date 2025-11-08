using CleanArch.UseCases.Goats.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Goats;

public partial class GoatController
{
    /// <summary> Retrieves a single goat by its unique identifier. </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>The goat DTO if found; 404 otherwise.</returns>
    /// <response code="200">Goat found.</response>
    /// <response code="404">Goat not found.</response>
    [ProducesResponseType(typeof(GoatDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{GoatId:int}", Name = "GetGoatById")]
    public async Task<ActionResult<GoatDTO>> GetGoatByIdAsync(GetGoatByIdRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _goatService.GetByIdAsync(request.GoatId, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
