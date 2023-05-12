using CustomerManagerApplication.IO.DTOs;
using CustomerManagerDomain.Models;

namespace CustomerManagerApplication.Utils
{
    public static class Mapper
    {
        public static CustomerDTO CustomerToCustomerDTO(Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                Gender = customer.Gender,
                BirthDate = customer.BirthDate,
                Address = customer.Address,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                Email = customer.Email,
            };
        }
    }
}
