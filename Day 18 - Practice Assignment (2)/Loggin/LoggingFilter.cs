using Microsoft.AspNetCore.Mvc.Filters;

public class LoggingFilter : IActionFilter
{
    private readonly ILoggingService _loggingService;

    public LoggingFilter(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        _loggingService.Log(
            $"Request: {request.Method} {request.Path}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var statusCode =
            context.HttpContext.Response.StatusCode;

        _loggingService.Log(
            $"Response Status: {statusCode}");
    }
}
