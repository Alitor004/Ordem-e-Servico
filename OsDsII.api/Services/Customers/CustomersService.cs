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
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _custumersRepository.GetAllCustomersAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _custumersRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Not Found");
            }
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync([FromBody] Customer newCustomer)
        {
            Customer currentCustomer = await _custumersRepository.CreateCustomerAsync(newCustomer);

            if (currentCustomer != null)
            {
                throw new Exception("Usuário já existe");
            }
            return newCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.UpdateCustomerAsync(id, customer);

            if (currentCustomer == null)
            {
                throw new Exception("Not found");
            }
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            Customer customer = await _custumersRepository.DeleteCustomerAsync(id);

            if (customer == null)
            {
                throw new Exception("Not found");
            }

            return customer;
        }
    }
}