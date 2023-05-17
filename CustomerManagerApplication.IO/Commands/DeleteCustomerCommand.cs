using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;


namespace CustomerManagerApplication.IO.Commands
{
    public class DeleteCustomerCommand : IValidationCommand<DeleteCustomerCommand>, IRequest<Unit>
    {
        public long Id { get; set; }

        public IValidator<DeleteCustomerCommand> Validator => new DeleteCustomerCommandValidator();

        public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
        {
            public DeleteCustomerCommandValidator()
            {
                RuleFor(element => element.Id).NotEmpty();
            }
        }
    }
}
