using Serilog.Context;

namespace Labour.MS.Adapter.Api.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.Items.ContainsKey("CorrelationId"))
            {
                context.Request.Headers.TryGetValue("CorrelationId", out var value);
                using (LogContext.PushProperty("CorrelationId", value))
                {
                    using (LogContext.PushProperty("RequestId", context.TraceIdentifier))
                    using (LogContext.PushProperty("UserId", context.User.Identity?.Name ?? "Anonymous"))
                    {
                        try
                        {
                            await _next(context);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "An unhandled exception occurred during request processing");
                            throw;
                        }
                    }
                    return;
                }
            }

            using (LogContext.PushProperty("RequestId", context.TraceIdentifier))
            using (LogContext.PushProperty("UserId", context.User.Identity?.Name ?? "Anonymous"))
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An unhandled exception occurred during request processing");
                    throw;
                }
            }
        }
    }
}
