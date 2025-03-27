using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManagement.Filters
{
    public class LogActionFilters : Attribute, IResultFilter
    {
        private Stopwatch _stopwatch;
        public void OnResultExecuting(ResultExecutingContext context)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            Console.WriteLine($"Executing: {context.ActionDescriptor.DisplayName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _stopwatch.Stop();

            Console.WriteLine($"Executed: {context.ActionDescriptor.DisplayName}. Elapsed: {_stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
