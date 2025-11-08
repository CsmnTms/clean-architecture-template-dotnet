using CleanArch.Core.shared.enums;

namespace CleanArch.Core.Goat;

public class Goat
{
    public int Id { get; set; }
    public required string Name { get; set; } // TODO_research: explore the required keyword
    public DateTime DateOfBirth { get; set; }
    public Sex Sex { get; set; }
    public string LastRecordedLocation { get; set; }
    public int TotalMilkCount { get; set; }
    public decimal TotalMilkQuantityLiters { get; set; }
}
