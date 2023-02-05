using MyClean.Application.Common.Models;
using ProductGallery.Domain.Enums;
using System.Net;

namespace ProductGallery.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _handler;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _handler = next;
        _logger = logger;
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
            AppStatusCode errorCode = error switch
            {
                ArgumentNullException => AppStatusCode.UnexpectedError,
                _ => AppStatusCode.UnexpectedError
            };

            string message = statusCode is (HttpStatusCode)500 ? "Internal Server Error" : error.Message;
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(ErrorResponse.Failure(errorCode, message));
            _logger.LogError(error, message);
        }
    }
}

public static class ErrorHandlerExtension
{
    public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder app) =>
        app.UseMiddleware<ErrorHandlerMiddleware>();
}
