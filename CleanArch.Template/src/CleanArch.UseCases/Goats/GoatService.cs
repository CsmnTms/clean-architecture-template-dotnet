using CleanArch.Core.Goat;
using CleanArch.Core.Goat.Specs;
using CleanArch.UseCases.Cows.DTOs;
using CleanArch.UseCases.Cows.Mappers;
using CleanArch.UseCases.Goats.DTOs;
using CleanArch.UseCases.Goats.Mappers;
using Common.SharedKernel;

namespace CleanArch.UseCases.Goats;

public class GoatService(IRepository<Goat> _goatRepository) : IGoatService
{
    public async Task<GoatDTO> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var spec = new GoatByIdSpec(id);
        var cow = await _goatRepository.FirstOrDefaultAsync(spec, ct);

        return cow.ToDto();
    }

    public async Task<IEnumerable<GoatDTO>> GetAllAsync(CancellationToken ct = default)
    {
        var list = await _goatRepository.ListAsync(ct);

        return list.Select(cow => cow.ToDto());
    }

    public async Task<GoatDTO> CreateAsync(GoatDTO goatDto, CancellationToken ct = default)
    {
        var createdCow = await _goatRepository.AddAsync(goatDto.ToEntity(), ct);

        return createdCow.ToDto();
    }

    public async Task<GoatDTO> UpdateAsync(GoatDTO goatDto, CancellationToken ct = default)
    {
        var existingGoat = await _goatRepository.GetByIdAsync(goatDto.Id, ct);
        if (existingGoat == null)
        {
            //return Result.NotFound();
        }

        await _goatRepository.UpdateAsync(goatDto.ToEntity(), ct);

        return goatDto;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
