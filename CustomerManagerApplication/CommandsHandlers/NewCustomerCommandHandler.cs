using CustomerManagerApplication.IO.Commands;
using CustomerManagerApplication.IO.DTOs;
using CustomerManagerApplication.Utils;
using CustomerManagerDomain.Models;
using CustomerManagerRepositories.Repositories;
using MediatR;

namespace CustomerManagerApplication.CommandsHandlers
{
    public  class NewCustomerCommandHandler : IRequestHandler<NewCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _repository;

        public NewCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDTO> Handle(NewCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Name = command.Name,
                LastName = command.LastName,
                Gender = command.Gender,
                BirthDate = command.BirthDate,
                Address = command.Address,
                Country = command.Country,
                PostalCode = command.PostalCode,
                Email = command.Email,
            };

            await _repository.Create(customer, cancellationToken);

            return Mapper.CustomerToCustomerDTO(customer); ;
        }
    }
}
