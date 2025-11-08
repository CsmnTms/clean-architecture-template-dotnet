using CleanArch.UseCases.Cows.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Goats;

public partial class GoatController
{
    /// <summary>Creates a new cow.</summary>
    [ProducesResponseType(typeof(GoatDTO), StatusCodes.Status201Created)]
    [HttpPost(Name = "AddCow")]
    public async Task<ActionResult> AddCowAsync([FromBody] CowDTO cowDto, CancellationToken cancellationToken = default)
    {
        var result = await _cowService.CreateAsync(cowDto, cancellationToken);

        // CreatedAtAction points clients to the canonical GET resource URL (/cows/{id})
        return CreatedAtAction(nameof(GetCowByIdAsync), new { id = result.Id }, result);
    }
}
