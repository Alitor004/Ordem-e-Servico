using OsDsII.api.Models;

namespace OsDsII.api.Services.Interfaces
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();

        public Task<Customer> GetCustomerByIdAsync(int id);
    }
}