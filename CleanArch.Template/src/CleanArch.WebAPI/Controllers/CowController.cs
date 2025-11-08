using CleanArch.UseCases.Cows;
using CleanArch.UseCases.Cows.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Controllers;

[Tags("cows")]
[ApiController]
[Route("cows")]
public class CowController(ICowService _cowService, ILogger<CowController> _logger) : ControllerBase
{
    /// <summary> Retrieves a single cow by its unique identifier. </summary>
    /// <param name="id">Numeric cow identifier.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The cow DTO if found; 404 otherwise.</returns>
    /// <response code="200">Cow found.</response>
    /// <response code="404">Cow not found.</response>
    [ProducesResponseType(typeof(CowDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}", Name = "GetCowById")]
    public async Task<ActionResult<CowDTO>> GetCowByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _cowService.GetByIdAsync(id, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    /// <summary> Lists cows (placeholder). </summary>
    [ProducesResponseType(typeof(IEnumerable<CowDTO>), StatusCodes.Status200OK)]
    [HttpGet(Name = "ListCows")]
    public async Task<ActionResult<IEnumerable<CowDTO>>> ListCowsAsync(CancellationToken cancellationToken = default)
    {
        var result = await _cowService.GetAllAsync(cancellationToken);

        return Ok(result);
    }

    /// <summary>Creates a new cow.</summary>
    [ProducesResponseType(typeof(CowDTO), StatusCodes.Status201Created)]
    [HttpPost(Name = "AddCow")]
    public async Task<ActionResult> AddCowAsync([FromBody] CowDTO cowDto, CancellationToken cancellationToken = default)
    {
        var result = await _cowService.CreateAsync(cowDto, cancellationToken);

        // CreatedAtAction points clients to the canonical GET resource URL (/cows/{id})
        return CreatedAtAction(nameof(GetCowByIdAsync), new { id = result.Id }, result);
    }

    /// <summary>Updates an existing cow.</summary>
    [ProducesResponseType(typeof(CowDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id:int}", Name = "UpdateCow")]
    public async Task<ActionResult<CowDTO>> UpdateCowAsync(int id, [FromBody] CowDTO cowDto, CancellationToken cancellationToken = default)
    {
        if (id != cowDto.Id) return BadRequest("Body id mismatch.");

        var updated = await _cowService.UpdateAsync(cowDto, cancellationToken);
        if (updated is null) return NotFound();

        return Ok(updated);
    }

    /// <summary>"Deletes" a cow.</summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:int}", Name = "DeleteCow")]
    public async Task<ActionResult> DeleteCowAsync(int id, CancellationToken cancellationToken = default)
    {
        var deleted = await _cowService.DeleteAsync(id, cancellationToken);

        if (!deleted) return NotFound();

        return NoContent();
    }
}
