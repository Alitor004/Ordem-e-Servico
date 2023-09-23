using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Services;
using OsDsII.api.Exceptions;
using OsDsII.api.Dto;
using OsDsII.api.Http;

namespace OsDsII.api.Controllers

{

    [ApiController]

    [Route("[controller]")]

    public class CustomersController : ControllerBase

    {
        private readonly ICustomersService _customersService;

        public CustomersController(DataContext dataContext, ICustomersService customersService)

        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

        {
            try
            {
                IEnumerable<Customer> customers = await _customersService.GetAllCustomersAsync();
                IEnumerable<CustomerDto> customersDto = customers.Select(c => c.ToCustomer());

                return HttpResponseApi<IEnumerable<CustomerDto>>.Ok(customersDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            try
            {
                Customer customer = await _customersService.GetCustomerByIdAsync(id);
                CustomerDto customerDto = customer.ToCustomer();

                return HttpResponseApi<CustomerDto>.Ok(customerDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.CreateCustomerAsync(customer);
                CustomerDto customerDto = currentCustomer.ToCustomer();

                return HttpResponseApi<CustomerDto>.Created(customerDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.UpdateCustomerAsync(id, customer);
                CustomerDto customerDto = currentCustomer.ToCustomer();

                return HttpResponseApi<CustomerDto>.Ok(customerDto);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            try
            {
                Customer customer = await _customersService.GetCustomerByIdAsync(id);
                await _customersService.RemoveCustomer(id, customer);

                CustomerDto customerDto = customer.ToCustomer();

                return HttpResponseApi<CustomerDto>.NoContent();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }









    }

}