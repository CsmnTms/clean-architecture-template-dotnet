using Common.SharedKernel;

namespace CleanArch.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T>(CowDbContext dbContext) :
    RepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : class//, IAggregateRoot
{
}
