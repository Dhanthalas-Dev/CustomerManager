using CustomerManagerApplication.IO.DTOs;
using CustomerManagerApplication.IO.Queries;
using CustomerManagerApplication.Utils;
using CustomerManagerRepositories.Repositories;
using MediatR;

namespace CustomerManagerApplication.QueriesHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return Mapper.CustomerToCustomerDTO(await _repository.GetbyId(request.CustomerId, cancellationToken));
        }
    }
}
