
using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class TimeLoggingMiddleware(ILogger<TimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        /*Log request time if it's longer than 4 seconds*/

        //start timer
        var stopwatch = Stopwatch.StartNew();
        
        await next.Invoke(context);
        
        //stop timer
        stopwatch.Stop();

        if(stopwatch.ElapsedMilliseconds > 4000)
        {
            var verb = context.Request.Method;
            var path = context.Request.Path;
            var time = stopwatch.ElapsedMilliseconds;
            logger.LogInformation($"Request [{verb}] at [{path}] took {time} ms.");
        }
    }
}
