using System.Diagnostics;

namespace AutoRepairShop.Web.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext ctx)
    {
        var req = ctx.Request;
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation("HTTP {Method} {Path} started", req.Method, req.Path);

        try
        {
            await _next(ctx);

            stopwatch.Stop();

            _logger.LogInformation("HTTP {Method} {Path} finished with {StatusCode} in {ElapsedMs} ms", req.Method,req.Path, ctx.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            _logger.LogError(ex, "HTTP {Method} {Path} failed in {ElapsedMs} ms", req.Method, req.Path, stopwatch.ElapsedMilliseconds);

            throw;
        }
    }
}
