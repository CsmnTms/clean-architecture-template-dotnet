using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebAPI.Goats;

public class GetGoatByIdRequest
{
    [FromRoute(Name = "goatId")]
    public int GoatId { get; set; }
}
