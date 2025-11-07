using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Core.Enums;

namespace CleanArch.UseCases.Cows.DTOs;

public record CowDTO
{
    public int Id { get; init; }
    public required string Name { get; init; } // TODO_research: explore the required keyword
    public DateTime DateOfBirth { get; init; }
    public Sex Sex { get; init; }
    public required string LastRecordedLocation { get; init; }
    public int TotalMilkCount { get; init; }
    public decimal TotalMilkQuantityLiters { get; init; }
}
