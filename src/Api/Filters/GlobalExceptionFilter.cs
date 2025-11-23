using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        _logger.LogError(exception, "Ocorreu um erro: {Message}", exception.Message);

        context.Result = exception switch
        {
            ValidationException validationException => new ObjectResult(new
            {
                message = "Erro de validação.",
                errors = validationException.Errors.Select(e => new
                {
                    property = e.PropertyName,
                    message = e.ErrorMessage
                })
            })
            {
                StatusCode = StatusCodes.Status400BadRequest
            },
            UnauthorizedAccessException => new ObjectResult(new { message = exception.Message })
            {
                StatusCode = StatusCodes.Status401Unauthorized
            },
            KeyNotFoundException => new ObjectResult(new { message = exception.Message })
            {
                StatusCode = StatusCodes.Status404NotFound
            },
            ArgumentException => new ObjectResult(new { message = exception.Message })
            {
                StatusCode = StatusCodes.Status400BadRequest
            },
            _ => new ObjectResult(new { message = "Ocorreu um erro interno no servidor." })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            }
        };

        context.ExceptionHandled = true;
    }
}
