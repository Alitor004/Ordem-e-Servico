using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Repositories.Interfaces;
using OsDsII.api.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OsDsII.api.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _customersRepository.GetAllCustomersAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _customersRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Not Found");
            }
            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            Customer currentCustomer = await _customersRepository.GetCustomerByEmailAsync(customer.Email);
            if (currentCustomer != null && currentCustomer.Equals(customer))
            {
                throw new Exception("Customer already exists.");
            }
            await _customersRepository.CreateCustomerAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return currentCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            Customer currentCustomer = await _customersRepository.GetCustomerByIdAsync(id);
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

        public async Task<Customer> RemoveCustomer(int id, Customer customer)
        {
            Customer currentCustomer = await _customersRepository.GetCustomerByIdAsync(id);
            await _customersRepository.RemoveCustomer(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer;
        }
    }
}