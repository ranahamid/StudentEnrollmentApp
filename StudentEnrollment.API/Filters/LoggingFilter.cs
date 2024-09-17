namespace StudentEnrollment.API.Filters
{
    public class LoggingFilter : IEndpointFilter
    {
        private readonly ILogger _logger;

        public LoggingFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggingFilter>();
        }

        public async  ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var path = context.HttpContext.Request.Path;
            _logger.LogInformation($"Request {method} {path} started");
            try
            {
                var result = await next(context);
                _logger.LogInformation($"Request {method} made to {path} successful");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred processing {method} {path}");
                return Results.Problem("An error occured. Please try again later");
            }
        }
    }
}
