using CustomerManagerApplication.IO.Commands;
using CustomerManagerApplication.IO.DTOs;
using CustomerManagerApplication.Utils;
using CustomerManagerDomain.Models;
using CustomerManagerRepositories.Repositories;
using MediatR;

namespace CustomerManagerApplication.CommandsHandlers
{
    public  class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
    {
        private readonly ICustomerRepository _repository;

        public UpdateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerDTO> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = command.Id,
                Name = command.Name,
                LastName = command.LastName,
                Gender = command.Gender,
                BirthDate = command.BirthDate,
                Address = command.Address,
                Country = command.Country,
                PostalCode = command.PostalCode,
                Email = command.Email,
            };

            await _repository.Update(customer, cancellationToken);

            return Mapper.CustomerToCustomerDTO(customer); ;
        }
    }
}
