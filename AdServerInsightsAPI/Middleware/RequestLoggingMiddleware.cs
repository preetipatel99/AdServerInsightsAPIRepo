using System.Diagnostics;

namespace AdServerInsightsAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var request = context.Request;

            // Log Request Details
            _logger.LogInformation($"Incoming Request: {request.Method} {request.Path}");

            await _next(context);

            stopwatch.Stop();
            var response = context.Response;

            // Log Response Details
            _logger.LogInformation($"Response: {response.StatusCode} - Processed in {stopwatch.ElapsedMilliseconds}ms");
        }
    }

}
