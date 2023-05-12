using FluentValidation;

namespace CustomerManagerApplication.IO
{
    public interface IValidationCommand<T>
    {
        IValidator<T> Validator { get; }
    }
}