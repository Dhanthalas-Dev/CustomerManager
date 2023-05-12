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
        public async Task Create(Customer customer, CancellationToken cancellationToken)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Customer customer, CancellationToken none)
        {
            var currentCustomer = await _dbContext.Customers.FindAsync(customer.Id);

            if (currentCustomer != null)
            {
                currentCustomer.Name = customer.Name;
                currentCustomer.LastName = customer.LastName;
                currentCustomer.Gender = customer.Gender;
                currentCustomer.BirthDate = customer.BirthDate;
                currentCustomer.Address = customer.Address;
                currentCustomer.Country = customer.Country;
                currentCustomer.PostalCode = customer.PostalCode;
                currentCustomer.Email = customer.Email;
                _dbContext.SaveChanges();
            }
        }
    }
}
