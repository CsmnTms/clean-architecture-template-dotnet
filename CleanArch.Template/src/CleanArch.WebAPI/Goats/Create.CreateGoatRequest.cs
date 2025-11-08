using CleanArch.Core.shared.enums;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Goats;

public class CreateGoatRequest
{
    public required string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public Sex Sex { get; init; }
}
