using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductGallery.Infrastructure.Data;

namespace ProductGallery.Persistence;

public static class StartupSetup
{
    public static IServiceCollection AddPersistenceInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {

        return services;
    }

    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)); // will be created in web project root
}