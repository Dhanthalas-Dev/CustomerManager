using FluentValidation;
using MediatR;

namespace CustomerManagerApplication.IO
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is IValidationCommand<TRequest> command)
            {
                var validationResult = await command.Validator.ValidateAsync((TRequest)command, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }
            var response = await next();

            return response;
        }
    }
}
