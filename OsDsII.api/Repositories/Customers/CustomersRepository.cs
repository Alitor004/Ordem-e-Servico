using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == newCustomer.Id);
            
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            
            return newCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);
            return customer;
        }



    }
}