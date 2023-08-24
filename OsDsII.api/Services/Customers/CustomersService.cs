using OsDsII.api.Models;
using OsDsII.api.Services.Interfaces;
using OsDsII.api.Repositories;



namespace OsDsII.api.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly  CustumersRepository _custumersRepository;

        public CustomersService( CustumersRepository custumersRepository )
        {
            _custumersRepository = custumersRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _custumersRepository.GetAllCustomersAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _custumersRepository.GetCustomerByIdAsync(id);
            if(customer == null)
                {
                    return NotFound();
                }
                return customer;
        }
    }
}