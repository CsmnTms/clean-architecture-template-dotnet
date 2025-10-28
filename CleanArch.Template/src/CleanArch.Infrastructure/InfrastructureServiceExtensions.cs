using CleanArch.Infrastructure.Data;
using CleanArch.Infrastructure.Data.SharedKernel;

namespace CleanArch.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        string? connectionString = config.GetConnectionString("SqliteConnection");
        //Guard.Against.Null(connectionString);

        services.AddDbContext<AppDbContext>(options =>
         options.UseSqlite(connectionString));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
               .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
               //.AddScoped<IService, Service>();

        logger.LogInformation("{Project} services registered", "Infrastructure");

        return services;
    }
}
