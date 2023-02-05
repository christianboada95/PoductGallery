using ProductGallery.Api.Extensions;
using ProductGallery.Api.Middlewares;
using ProductGallery.Application;
using ProductGallery.Persistence;
using System.Text.Json.Serialization;

namespace ProductGallery.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddPersistenceInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddSecurityConfiguration();
        builder.Services.AddControllers()
            //.ConfigureApiBehaviorOptions(op => op.SuppressModelStateInvalidFilter = true)
            .AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                op.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthorization();

        //app.UseWelcomePage();
        app.UseErrorHandlerMiddleware();

        app.MapControllers();

        app.Run();
    }
}