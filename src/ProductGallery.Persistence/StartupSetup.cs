﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductGallery.Application.Interfaces;
using ProductGallery.Domain.Contracts;
using ProductGallery.Domain.Entities;
using ProductGallery.Infrastructure.Data;
using ProductGallery.Persistence.Data;
using ProductGallery.Persistence.Repositories;
using ProductGallery.Persistence.Storages;

namespace ProductGallery.Persistence;

public static class StartupSetup
{
    public static IServiceCollection AddPersistenceInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext(config.GetConnectionString("SqlServer")!);
        services.AddBlobStorage(config.GetConnectionString("BlobStorage")!);

        #region Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        #endregion

        services.AddScoped<IFileStorage<ProductImage>, ImageStorage>();

        return services;
    }

    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

    public static void AddBlobStorage(this IServiceCollection services, string connectionString) =>
        services.AddSingleton<AppStorageClient>(x =>
            new AppStorageClient(connectionString));
}