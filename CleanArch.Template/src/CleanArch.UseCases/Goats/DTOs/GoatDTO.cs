using CleanArch.Core.shared.enums;

namespace CleanArch.UseCases.Goats.DTOs;

public class GoatDTO
{
    public int Id { get; set; }
    public required string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Sex Sex { get; init; }
    public required string LastRecordedLocation { get; init; }
    public int TotalMilkCount { get; init; }
    public decimal TotalMilkQuantityLiters { get; init; }
}
