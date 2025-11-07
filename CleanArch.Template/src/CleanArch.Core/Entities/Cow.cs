using CleanArch.Core.Enums;

namespace CleanArch.Core.Entities;

public class Cow
{
    public int Id { get; set; }
    public required string Name { get; set; } // TODO_research: explore the required keyword
    public DateTime DateOfBirth { get; set; }
    public Sex Sex { get; set; }
    public string LastRecordedLocation { get; set; }
    public int TotalMilkCount { get; set; }
    public decimal TotalMilkQuantityLiters { get; set; }
    //public int Age => DateTime.Now.Year - DateOfBirth.Year;
}
