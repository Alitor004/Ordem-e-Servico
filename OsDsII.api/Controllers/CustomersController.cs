using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OsDsII.api.Models;
using OsDsII.api.Data;
using OsDsII.api.Repositories.Interfaces;

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
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Customer> listaDeCustomer = await _customersRepository.GetAllCustomersAsync();
                return Ok(listaDeCustomer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);
                
                
                if(customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer newCustomer)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == newCustomer.Id);
                if(customer != null && customer.Equals(newCustomer))
                {
                    return BadRequest("Usuárioa já existe");
                }

                await _context.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
                return Ok(newCustomer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Customer deleteCustomer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);

                _context.Customers.Remove(deleteCustomer);
                await _context.SaveChangesAsync();
                return Ok(deleteCustomer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCustomer(int id, Customer customer)
        {
            try
            {
                Customer currentCustomer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);

                _context.Customers.Update(currentCustomer);
                await _context.SaveChangesAsync();
                
                return Ok(customer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }









    }
}