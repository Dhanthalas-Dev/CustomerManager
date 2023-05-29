using CustomerManagerDomain.Enums;

namespace CustomerManagerApplication.IO.DTOs
{
    public class CustomerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public string Email { get; set; }
    }
}