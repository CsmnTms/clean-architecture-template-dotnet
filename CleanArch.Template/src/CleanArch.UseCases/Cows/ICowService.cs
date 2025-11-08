using CleanArch.UseCases.Cows.DTOs;

namespace CleanArch.UseCases.Cows;

public interface ICowService
{
    Task<CowDTO> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<IEnumerable<CowDTO>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<CowDTO> CreateAsync(CowDTO cowDto, CancellationToken cancellationToken = default);

    Task<CowDTO> UpdateAsync(CowDTO cowDto, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
