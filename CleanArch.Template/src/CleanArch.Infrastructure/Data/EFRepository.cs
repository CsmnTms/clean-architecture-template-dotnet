using Common.SharedKernel;

namespace CleanArch.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T>(FarmDbContext dbContext) :
    RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class//, IAggregateRoot
{
}
