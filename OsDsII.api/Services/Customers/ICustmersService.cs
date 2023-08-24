<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
=======
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
using OsDsII.api.Models;

namespace OsDsII.api.Services.Interfaces
{
    public interface ICustomersService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
<<<<<<< HEAD

        public Task<Customer> GetCustomerByIdAsync(int id);

        public Task<Customer> CreateCustomerAsync([FromBody] Customer customer);

        public Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer);
=======
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
    }
}