using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Middlewares;

public class ValidationExceptionHandlerMiddleware : IExceptionHandler
{
    private readonly ILogger<ValidationExceptionHandlerMiddleware> _logger;

    public ValidationExceptionHandlerMiddleware(ILogger<ValidationExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationResultErrors validationResultErrors)
        {
            return false;
        }

        _logger.LogError("An Exception {Message} Occurred at {DateTime}",
                        validationResultErrors.Message,
                        DateTime.Now);

        var problem = new ProblemDetails()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = validationResultErrors.GetType().Name,
            Detail = validationResultErrors.Message,
            Instance = httpContext.Request.Path,
            Type = validationResultErrors.GetType().Name,
            Extensions = new Dictionary<string, object?>()
            {
                { "errors", new[] { validationResultErrors.Errors } }
            }
        };


        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);

        return true;

    }
}
