using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Models;

namespace OsDsII.api.Repositories.Interfaces
{
    public interface ICustomersRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();

        public Task<Customer> GetCustomerByIdAsync(int id);

        public Task CreateCustomerAsync(Customer customer);

        public Task RemoveCustomer(Customer customer);
    }
}