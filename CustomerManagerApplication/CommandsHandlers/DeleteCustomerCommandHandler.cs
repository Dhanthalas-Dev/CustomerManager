using CustomerManagerApplication.IO.Commands;
using CustomerManagerRepositories.Repositories;
using MediatR;

namespace CustomerManagerApplication.CommandsHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            await _repository.Delete(command.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
