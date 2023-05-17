using CustomerManagerApplication.IO.DTOs;
using CustomerManagerDomain.Enums;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace CustomerManagerApplication.IO.Commands
{
    public class UpdateCustomerCommand : IValidationCommand<UpdateCustomerCommand>, IRequest<CustomerDTO>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }

        public IValidator<UpdateCustomerCommand> Validator => new UpdateCustomerCommandValidator();
        public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
        {
            public UpdateCustomerCommandValidator()
            {
                RuleFor(element => element.Id).NotEmpty();
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