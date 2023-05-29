using CustomerManagerApplication.IO.DTOs;
using CustomerManagerDomain.Enums;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace CustomerManagerApplication.IO.Commands
{
    public class NewCustomerCommand : IValidationCommand<NewCustomerCommand>, IRequest<CustomerDTO>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }

        public IValidator<NewCustomerCommand> Validator => new NewCustomerCommandValidator();

        public class NewCustomerCommandValidator : AbstractValidator<NewCustomerCommand>
        {
            public NewCustomerCommandValidator()
            {
                RuleFor(element => element.Name).NotEmpty();
                RuleFor(element => element.LastName).NotEmpty();
                RuleFor(element => element.Gender).IsInEnum();
                RuleFor(element => element.BirthDate).NotEmpty().NotEqual(default(DateTime));
                RuleFor(element => element.Address).NotEmpty();
                RuleFor(element => element.Country).NotEmpty();
                RuleFor(element => element.PostalCode).NotEmpty();
                RuleFor(element => element.Email).NotEmpty().EmailAddress();
            }
        }
    }
}
