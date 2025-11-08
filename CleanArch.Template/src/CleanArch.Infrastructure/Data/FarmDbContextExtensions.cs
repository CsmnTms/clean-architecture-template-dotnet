namespace CleanArch.Infrastructure.Data;

public static class FarmDbContextExtensions
{
    public static void AddFarmDbContext(this IServiceCollection services, string connectionString)
    {
        //services.AddDbContext<FarmDbContext>(options =>
        //    options.UseSqlite(connectionString));

        services.AddDbContext<FarmDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(typeof(FarmDbContext).Assembly.FullName); // TODO_research 
                sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null); // TODO_research
            });
        });
    }
}

