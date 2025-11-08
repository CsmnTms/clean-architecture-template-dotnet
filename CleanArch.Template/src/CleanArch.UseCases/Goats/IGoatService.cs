using CleanArch.UseCases.Goats.DTOs;

namespace CleanArch.UseCases.Goats;

internal interface IGoatService
{
    Task<GoatDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<IEnumerable<GoatDTO>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<GoatDTO> CreateAsync(GoatDTO cowDto, CancellationToken cancellationToken = default);

    Task<GoatDTO> UpdateAsync(GoatDTO cowDto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
