namespace HospitalManagement.Middleware
{
    public class GlobalLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalLoggingMiddleware> _logger;

        public GlobalLoggingMiddleware(RequestDelegate next,
            ILogger<GlobalLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Executing: {context.Request.Path}");
            _logger.LogInformation("Executing: {@Path}", context.Request.Path);
            await _next(context);
            _logger.LogInformation("Executing: {@Path}", context.Request.Path);
            Console.WriteLine($"Executed: {context.Request.Path}");
        }
    }
}
