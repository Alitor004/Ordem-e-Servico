using OsDsII.api.Models;
using OsDsII.api.Services.Interfaces;



namespace OsDsII.api.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly  ContomersRepository ;

        public CustumersRepository( )
        {
            
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
    }
}