using CustomerManagerDomain.Models;

namespace CustomerManagerRepositories.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll(CancellationToken none);
        Task<Customer> GetbyId(long customerId, CancellationToken none);
    }
}
