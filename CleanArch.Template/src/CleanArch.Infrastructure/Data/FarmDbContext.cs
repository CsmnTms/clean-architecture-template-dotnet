using System.Reflection;
using CleanArch.Core.Cow;
using CleanArch.Core.Goat;

namespace CleanArch.Infrastructure.Data;

// from root folder (same as .slnx)
// dotnet ef migrations add InitialCreate_SqlServer --project src/CleanArch.Infrastructure --startup-project src/CleanArch.WebAPI --output-dir Data\Migrations
// dotnet ef database update --project src/CleanArch.Infrastructure --startup-project src/CleanArch.WebAPI
public class FarmDbContext(DbContextOptions<FarmDbContext> options) : DbContext(options)
{
    public DbSet<Cow> Cows => Set<Cow>();

    public DbSet<Goat> Goats => Set<Goat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // TODO_research: see what this does
    }
}
