using CleanArch.Infrastructure.Data;
using Common.SharedKernel;

namespace CleanArch.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        //string? connectionString = config.GetConnectionString("SqliteConnection");
        string? connectionString = config.GetConnectionString("SqlServerConnection");
        //Guard.Against.Null(connectionString);

        services.AddDbContext<CowDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sql =>
            {
                sql.MigrationsAssembly(typeof(CowDbContext).Assembly.FullName); // TODO_research 
                sql.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null); // TODO_research
            });
        });

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>)); 
              //.AddScoped<IService, Service>();

        logger.LogInformation("{Project} services registered", "Infrastructure");

        return services;
    }
}
