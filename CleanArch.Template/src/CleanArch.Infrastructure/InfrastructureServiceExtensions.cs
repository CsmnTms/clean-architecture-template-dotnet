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

        services.AddFarmDbContext(connectionString);

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>)); 
              //.AddScoped<IService, Service>();

        logger.LogInformation("{Project} services registered", "Infrastructure");

        return services;
    }
}
