using CustomerManagerDomain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace CustomerManagerWebApi.Extensions
{
    public static class ExceptionHandlingExtension
    {
        public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var errorResponse = new ErrorResponse
                        {
                            Message = "An error occurred while processing your request.",
                            Error = exceptionHandlerFeature.Error.Message
                        };

                        if (exceptionHandlerFeature.Error is ValidationException validationException)
                        {
                            errorResponse.Message = "Validation failed.";
                            errorResponse.Error = exceptionHandlerFeature.Error.Message;
                            errorResponse.Details = validationException.Errors;
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        }

                        if (exceptionHandlerFeature.Error is BusinessRuleException businessRuleException)
                        {
                            errorResponse.Message = exceptionHandlerFeature.Error.Message;
                            errorResponse.Error = exceptionHandlerFeature.Error.Message;
                            context.Response.StatusCode = StatusCodes.Status404NotFound;
                        }

                        await context.Response.WriteAsJsonAsync(errorResponse);
                    }
                });
            });

            return app;
        }
    }
}
