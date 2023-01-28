using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Infrastructure.Data;
using ProductGallery.Persistence.Repositories;

namespace ProductGallery.Persistence;

public static class StartupSetup
{
    public static IServiceCollection AddPersistenceInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext(config.GetConnectionString("SqlServer")!);

        #region Repositories
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        #endregion

        return services;
    }

    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
}