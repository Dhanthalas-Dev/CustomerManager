using FluentValidation;
using System.Text.Json.Serialization;

namespace CustomerManagerApplication.IO
{
    public interface IValidationCommand<T>
    {
        [JsonIgnore]
        IValidator<T> Validator { get; }
    }
}