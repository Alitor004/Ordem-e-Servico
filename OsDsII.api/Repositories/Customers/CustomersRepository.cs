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
    }
}