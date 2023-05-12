using CustomerManagerDomain.Exceptions;
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

        public async Task<Customer> GetbyId(long id, CancellationToken none)
        {
            var currentCustomer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
            return currentCustomer ?? throw new BusinessRuleException("The customer with the given id does not exist");
        }
    }
}
