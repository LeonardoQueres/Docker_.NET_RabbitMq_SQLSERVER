using FluentValidation;
using Restaurante_Borders.Shared;
using Restaurante_Borders.Shared.Exceptions;
using Restaurante_Borders.Shared.Extensions;
using System.Net;
using System.Text.Json;

namespace Restaurante_Api.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddleware> logger)
        {
            var (code, errorMessage, errors) = exception switch
            {
                RepositoryException ex => (ex.StatusCode, ex.Message, ex.Errors),
                ValidationException e => (HttpStatusCode.BadRequest, ErrorCodes.ValidationError, e.ToErrorMessage()),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error", new ErrorMessage[] { ErrorMessages.InternalServerError })
            };

            if (errorMessage is not null)
                logger.LogError(exception, "{@ErrorMessage} {@Errors}", errorMessage, errors);

            if (HttpStatusCode.BadGateway == code)
            {
                errors ??= Array.Empty<ErrorMessage>();
                errors = errors.Append(ErrorMessages.BadGateway);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(JsonSerializer.Serialize(errors, JsonExtensions.DefaultSerializerOptions));
        }
    }
}
