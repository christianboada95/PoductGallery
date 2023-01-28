using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductGallery.Application.Interfaces;
using ProductGallery.Application.Services;
using System.Reflection;

namespace ProductGallery.Application;

public static class StartupSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IInventoryService, InventoryService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}