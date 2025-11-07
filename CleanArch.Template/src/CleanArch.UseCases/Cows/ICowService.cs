using CleanArch.Core.Entities;
using CleanArch.UseCases.Cows.DTOs;

namespace CleanArch.UseCases.Cows;

public interface ICowService
{
    Task<CowDTO> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<CowDTO>> GetAllAsync(CancellationToken cancellationToken);

    Task<CowDTO> CreateAsync(CowDTO cowDto, CancellationToken cancellationToken);

    Task<CowDTO> UpdateAsync(CowDTO cowDto, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
