using CleanArch.Core.shared.enums;

namespace CleanArch.WebAPI.Goats;

public record GoatRecord
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Sex Sex { get; init; }
}
