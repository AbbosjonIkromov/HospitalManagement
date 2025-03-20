using Microsoft.Extensions.Primitives;
using Serilog;
using Serilog.Context;

namespace HospitalManagement.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CorrelationIdMiddleware> logger;

        public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var scope = new Dictionary<string, string>()
            {
                { "CorrelationId", Guid.NewGuid().ToString() }
            };

            using (logger.BeginScope(scope))
            {
                await next(context);
            }
        }
    }
}
