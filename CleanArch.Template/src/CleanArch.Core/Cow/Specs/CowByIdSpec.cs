using Ardalis.Specification;

namespace CleanArch.Core.Cow.Specs;

public class CowByIdSpec : Specification<Cow>
{
    public CowByIdSpec(int cowId) =>
        Query
            .Where(cow => cow.Id == cowId);
}
