using CustomerManagerDomain.Models;

namespace CustomerManagerRepositories.Repositories
{
    public interface ICustomerRepository
    {
        Task Create(Customer customer, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
        Task<IEnumerable<Customer>> GetAll(CancellationToken none);
        Task<Customer> GetbyId(long customerId, CancellationToken none);
        Task Update(Customer customer, CancellationToken cancellationToken);
    }
}
