using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Core.Cow;
using CleanArch.UseCases.Cows.DTOs;

namespace CleanArch.UseCases.Cows.Mappers;

public static class CowMapper
{
    /// <summary>
    /// Maps a domain Cow entity to a CowDTO.
    /// </summary>
    public static CowDTO ToDto(this Cow cow)
    {
        if (cow is null) throw new ArgumentNullException(nameof(cow));

        return new CowDTO
        {
            Id = cow.Id,
            Name = cow.Name,
            DateOfBirth = cow.DateOfBirth,
            Sex = cow.Sex,
            LastRecordedLocation = cow.LastRecordedLocation,
            TotalMilkCount = cow.TotalMilkCount,
            TotalMilkQuantityLiters = cow.TotalMilkQuantityLiters
        };
    }

    /// <summary>
    /// Maps a CowDTO to a domain Cow entity.
    /// </summary>
    public static Cow ToEntity(this CowDTO dto)
    {
        if (dto is null) throw new ArgumentNullException(nameof(dto));

        return new Cow
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
