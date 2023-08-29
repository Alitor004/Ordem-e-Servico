using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Services.Interfaces;
using OsDsII.api.Repositories.Interfaces;
using OsDsII.api.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OsDsII.api.Services
{
    public class CustumersService : ICustomersService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICustomersRepository _custumersRepository;

        public CustumersService(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _custumersRepository = customersRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.GetCustomerByIdAsync(customer.Id);
            if (currentCustomer != null && currentCustomer.Equals(customer))
            {
                throw new Exception("Customer already exists.");
            }
            await _custumersRepository.CreateCustomerAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return currentCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.GetCustomerByIdAsync(id);
            if (currentCustomer == null)
            {
                throw new Exception("Not found");
            }

            currentCustomer.Name = customer.Name;
            currentCustomer.Email = customer.Email;
            currentCustomer.Phone = customer.Phone;
            await _unitOfWork.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id, Customer customer)
        {
            Customer currentCustomer = await _custumersRepository.GetCustomerByIdAsync(id);
            await _custumersRepository.RemoveCustomer(id, customer);
            await _unitOfWork.SaveChangesAsync();

            return customer;
        }
    }
}