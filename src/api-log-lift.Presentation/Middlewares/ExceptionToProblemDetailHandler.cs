using api_log_lift.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace api_log_lift.Presentation.Middleware;

public class ExceptionToProblemDetailsHandler : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
{
  private static readonly Dictionary<Type, (int StatusCode, string Type, string Title)> ExceptionDetails = new()
    {
        {typeof(NotFoundException), (StatusCodes.Status404NotFound, "https://datatracker.ietf.org/doc/html/rfc9110#name-404-not-found", "Not Found") },
        {typeof(InvalidCredentialsException), (StatusCodes.Status401Unauthorized, "https://datatracker.ietf.org/doc/html/rfc9110#name-401-unauthorized", "Unauthorized")},
        {typeof(SaveDatabaseException), (StatusCodes.Status500InternalServerError, "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error", "Internal Server Error")},
        {typeof(ConflictException), (StatusCodes.Status409Conflict, "https://datatracker.ietf.org/doc/html/rfc9110#name-409-conflict", "Conflict")}
    };

  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    var exceptionType = exception.GetType();
    var (statusCode, type, title) = ExceptionDetails.GetValueOrDefault(exceptionType,
        (StatusCodes.Status500InternalServerError,
        "https://datatracker.ietf.org/doc/html/rfc9110#name-500-internal-server-error",
        "Internal Server Error"));

    var problemDetails = new ProblemDetails
    {
      Title = title,
      Detail = exception.Message,
      Type = type,
      Status = statusCode,
    };

    httpContext.Response.StatusCode = statusCode;
    httpContext.Response.ContentType = "application/problem+json";
    await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);

    return true;
  }
}
