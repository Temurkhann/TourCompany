using ProtoolsStore.Services;

namespace ProtoolsStore.Api.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try 
        {
            await _next.Invoke(httpContext);
        }
        catch (HttpException ex)
        {
            httpContext.Response.StatusCode = ex.StatusCodeNumeric;

            await httpContext.Response.WriteAsJsonAsync( new
            {
                ex.StatusCodeNumeric,
                ex.Message
            });
        }
        catch (Exception ex)
        {
            // logger in there
            _logger.LogError(ex.ToString());

            httpContext.Response.StatusCode = 500;

            await httpContext.Response.WriteAsJsonAsync(new
            {
                Code = 500,
                ex.Message
            });
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}