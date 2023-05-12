using CustomerManagerApplication.IO.DTOs;
using FluentValidation;
using MediatR;

namespace CustomerManagerApplication.IO.Queries
{
    public class GetCustomerByIdQuery : IValidationCommand<GetCustomerByIdQuery>, IRequest<CustomerDTO>
    {
        public long CustomerId { get; set; }
        public IValidator<GetCustomerByIdQuery> Validator => new GetCustomerByIdQueryValidator();

        public class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery> {

            public GetCustomerByIdQueryValidator()
            {
                RuleFor(element => element.CustomerId).NotEmpty();
            }
        }
    }
}