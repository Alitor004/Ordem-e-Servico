using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Repositories.Interfaces;

namespace OsDsII.api.Repositories
{
    public class CustumersRepository : ICustomersRepository
    {
        private readonly DataContext _context;

        public CustumersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer customer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customers = await _context.Customers.FirstOrDefaultAsync(c => id == c.Id);
            return customers;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(c => id == c.Id);

            return customer;
        }
    }
}