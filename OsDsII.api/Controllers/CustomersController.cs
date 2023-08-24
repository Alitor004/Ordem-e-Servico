using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Mvc;

using OsDsII.api.Data;
using OsDsII.api.Repositories.Interfaces;

<<<<<<< HEAD
using OsDsII.api.Models;

using OsDsII.api.Services.Interfaces;

namespace OsDsII.api.Controllers

{

    [ApiController]

    [Route("[controller]")]

    public class CustomersController : ControllerBase

    {

        private readonly DataContext _dataContext;

        private readonly ICustomersService _customersService;

        public CustomersController(DataContext dataContext, ICustomersService customersService)

        {

            _dataContext = dataContext;

            _customersService = customersService;

=======
namespace OsDsII.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICustomersRepository _customersRepository;

        public CustomersController(DataContext context, ICustomersRepository cuustomersRepository)
        {
            _context = context;
            _customersRepository = cuustomersRepository;
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()

        {

            try

            {
<<<<<<< HEAD

                IEnumerable<Customer> customers = await _customersService.GetAllCustomersAsync();

                return Ok(customers);

=======
                IEnumerable<Customer> listaDeCustomer = await _customersRepository.GetAllCustomersAsync();
                return Ok(listaDeCustomer);
>>>>>>> 835e8e1425c4562ec45c06d9a77547c98f3f2bb9
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
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                Customer currentCustomer = await _customersService.CreateCustomerAsync(c => c.Id == customer.Id);

                await _dataContext.AddAsync(customer);
                await _dataContext.SaveChangesAsync();
                return Ok(customer);
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

                currentCustomer.Name = customer.Name;
                currentCustomer.Email = customer.Email;
                currentCustomer.Phone = customer.Phone;
                await _dataContext.SaveChangesAsync();
                return Ok();
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
                Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(c => id == c.Id);

                if (customer is null)
                {
                    throw new Exception("Not found");
                }
                _dataContext.Customers.Remove(customer);
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }

}