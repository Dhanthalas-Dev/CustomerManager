using CustomerManagerApplication.IO.DTOs;
using FluentValidation;
using MediatR;

namespace CustomerManagerApplication.IO.Queries
{
    public class GetCustomersQuery : IValidationCommand<GetCustomersQuery>, IRequest<IEnumerable<CustomerDTO>>
    {
        public IValidator<GetCustomersQuery> Validator => new GetCustomersQueryValidator();

        public class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery> { }
    }
}