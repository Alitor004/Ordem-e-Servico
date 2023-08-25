using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

using OsDsII.api.Data;

using OsDsII.api.Models;

using OsDsII.api.Services.Interfaces;

namespace OsDsII.api.Controllers

{

    [ApiController]

    [Route("[controller]")]

    public class CustomersController : ControllerBase

    {

        private readonly DataContext _context;

        private readonly ICustomersService _customersService;

        public CustomersController(DataContext dataContext, ICustomersService customersService)

        {

            _context = dataContext;

            _customersService = customersService;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()

        {

            try

            {

                IEnumerable<Customer> customers = await _customersService.GetAllCustomersAsync();

                return Ok(customers);

            }

            catch (Exception ex)

            {

                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            try
            {
                Customer customer = await _customersService.GetCustomerByIdAsync(id);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer newCustomer)
        {
            try
            {
                Customer existingCustomer = await _customersService.CreateCustomerAsync(newCustomer);

                return Ok(newCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.UpdateCustomerAsync(id, customer);

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            try
            {
                Customer customer = await _customersService.DeleteCustomerAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }

}