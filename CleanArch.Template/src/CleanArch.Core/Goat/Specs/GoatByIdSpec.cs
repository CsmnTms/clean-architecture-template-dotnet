using Ardalis.Specification;

namespace CleanArch.Core.Goat.Specs;

public class GoatByIdSpec : Specification<Goat>
{
    public GoatByIdSpec(int goatId) =>
        Query
            .Where(cow => cow.Id == goatId);
}
