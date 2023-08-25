using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Models;

namespace OsDsII.api.Services.Interfaces
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();

        public Task<Customer> GetCustomerByIdAsync(int id);

        public Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer);

        public Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer);

        public Task<Customer> DeleteCustomerAsync(int id);
    }
}