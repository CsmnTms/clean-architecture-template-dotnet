namespace CleanArch.Infrastructure.Data;

public static class CowDbContextExtensions
{
    public static void AddCowDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<CowDbContext>(options =>
            options.UseSqlite(connectionString));
}

