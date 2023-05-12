using CustomerManagerDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagerRepositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetAll(CancellationToken none)
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
