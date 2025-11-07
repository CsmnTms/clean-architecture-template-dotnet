using System.Threading;
using CleanArch.Core.Cow;
using CleanArch.Core.Cow.Specs;
using CleanArch.Core.Enums;
using CleanArch.UseCases.Cows.DTOs;
using CleanArch.UseCases.Cows.Mappers;
using Common.SharedKernel;

namespace CleanArch.UseCases.Cows;

public class CowService(IRepository<Cow> _cowRepository) : ICowService
{
    public async Task<CowDTO> GetByIdAsync(int id, CancellationToken ct)
    {
        var spec = new CowByIdSpec(id);
        var cow = await _cowRepository.FirstOrDefaultAsync(spec, ct);

        return cow.ToDto();
    }

    public async Task<IEnumerable<CowDTO>> GetAllAsync(CancellationToken ct)
    {
        var list = await _cowRepository.ListAsync(ct);

        return list.Select(cow => cow.ToDto());
    }

    public async Task<CowDTO> CreateAsync(CowDTO cowDto, CancellationToken ct)
    {
        var createdCow = await _cowRepository.AddAsync(cowDto.ToEntity(), ct);

        return createdCow.ToDto();
    }

    public async Task<CowDTO> UpdateAsync(CowDTO cowDto, CancellationToken ct)
    {
        var existingContributor = await _cowRepository.GetByIdAsync(cowDto.Id, ct);
        if (existingContributor == null)
        {
            //return Result.NotFound();
        }

        await _cowRepository.UpdateAsync(cowDto.ToEntity(), ct);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
