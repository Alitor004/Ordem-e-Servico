<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Services.Interfaces;
using OsDsII.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OsDsII.api.Services
{
    public class CustumersService : ICustomersService
    {
        private readonly DataContext _context;

        private readonly ICustomersRepository _custumersRepository;

        public CustumersService(DataContext context, ICustomersRepository customersRepository)
        {
            _context = context;
            _custumersRepository = customersRepository;
=======
using OsDsII.api.Models;
using OsDsII.api.Services.Interfaces;



namespace OsDsII.api.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly  ContomersRepository ;

        public CustumersRepository( )
        {
            
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
<<<<<<< HEAD
            IEnumerable<Customer> customers = await _custumersRepository.GetAllCustomersAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _custumersRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
        
        public async Task<Customer> CreateCustomerAsync([FromBody] Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.CreateCustomerAsync(customer);

            if (currentCustomer != null && currentCustomer.Equals(customer))
            {
                return BadRequest("Usuário já existe");
            }
            return Ok(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.UpdateCustomerAsync(id, customer);

            if (currentCustomer is null)
            {
                throw new Exception("Not found");
            }
            return customer;
        }
=======
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
    }
}