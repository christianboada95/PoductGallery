using ProductGallery.Application.DataTransferObjects;
using System.Net;

namespace ProductGallery.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _handler;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _handler = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _handler(context);
        }
        catch (Exception error)
        {
            //context.Response = 
            HttpStatusCode statusCode = error switch
            {
                ArgumentNullException => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.InternalServerError
            };
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(new Response<string>(error.Message));
        }
    }
}

public static class ErrorHandlerExtension
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ErrorHandlerMiddleware>();
}
