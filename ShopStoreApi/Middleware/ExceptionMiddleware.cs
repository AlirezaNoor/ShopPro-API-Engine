using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopStoreApi.Errors;

namespace ShopStoreApi.Middleware;

public class ExceptionMiddleware
{
    public ILogger<ExceptionMiddleware> Logger { get; }
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment _env)
    {
        Logger = logger;
        _next = next;
        this._env = _env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = _env.IsDevelopment()
                ? new Exceptionhandler((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace.ToString())
                : new Exceptionhandler((int)HttpStatusCode.InternalServerError);
            var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response,option);
            await context.Response.WriteAsync(json);
        }
    }
}