using System.Reflection;
using CleanArch.Core.Entities;

namespace CleanArch.Infrastructure.Data;

public class CowDbContext(DbContextOptions<CowDbContext> options) : DbContext(options)
{
    public DbSet<Cow> Cows => Set<Cow>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // TODO_research: see what this does
    }
}
