namespace ProductGallery.Api.Extensions;

public static class SecurityExtension
{
    public static IServiceCollection AddSecurityConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.SetIsOriginAllowed(IsOriginAllowed);
                builder.AllowAnyHeader();
                builder.DisallowCredentials();
                builder.WithMethods("POST", "GET", "PUT", "DELETE", "OPTION");
            });
        });

        services.AddAntiforgery();
        services.AddHsts(options =>
        {
            options.MaxAge = TimeSpan.FromDays(30);
            options.IncludeSubDomains = true;
        });

        return services;
    }

    private static bool IsOriginAllowed(string origin)
    {
        return Uri.TryCreate(origin, UriKind.Absolute, out Uri uri) || uri.Host.Equals("localhhost");
    }
}