using Microsoft.Extensions.Options;

namespace HospitalManagement.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (OptionsValidationException e)
            {
                _logger.LogError("GlobalMiddleware: " + e.Message);
                throw new InvalidOperationException("Configuration validation Error");
            }

        }
    }
}
