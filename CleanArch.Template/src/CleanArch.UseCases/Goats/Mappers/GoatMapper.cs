using CleanArch.Core.Goat;
using CleanArch.UseCases.Goats.DTOs;

namespace CleanArch.UseCases.Goats.Mappers;

public static class GoatMapper
{
    /// <summary>
    /// Maps a domain Goat entity to a GoatDTO.
    /// </summary>
    public static GoatDTO ToDto(this Goat goat)
    {
        if (goat is null) throw new ArgumentNullException(nameof(goat));

        return new GoatDTO
        {
            Id = goat.Id,
            Name = goat.Name,
            DateOfBirth = goat.DateOfBirth,
            Sex = goat.Sex,
            LastRecordedLocation = goat.LastRecordedLocation,
            TotalMilkCount = goat.TotalMilkCount,
            TotalMilkQuantityLiters = goat.TotalMilkQuantityLiters
        };
    }

    /// <summary>
    /// Maps a GoatDTO to a domain Goat entity.
    /// </summary>
    public static Goat ToEntity(this GoatDTO dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        return new Goat
        {
            Id = dto.Id,
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth,
            Sex = dto.Sex,
            LastRecordedLocation = dto.LastRecordedLocation,
            TotalMilkCount = dto.TotalMilkCount,
            TotalMilkQuantityLiters = dto.TotalMilkQuantityLiters
        };
    }
}
