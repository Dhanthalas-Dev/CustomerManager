using CustomerManagerApplication.IO.Queries;
using CustomerManagerApplication.IO.DTOs;
using MediatR;
using CustomerManagerRepositories.Repositories;
using CustomerManagerApplication.Utils;

namespace CustomerManagerApplication.QueriesHandler
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDTO>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetAll(cancellationToken))
                .Select(Mapper.CustomerToCustomerDTO);
        }
    }
}