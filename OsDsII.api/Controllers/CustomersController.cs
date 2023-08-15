using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Models;
using OsDsII.api.Data;
using Microsoft.EntityFrameworkCore;

namespace OsDsII.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Customer> listaDeCustomer = await _context.Customers
                    .ToListAsync();
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
                
                return Ok(customer);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer newCustomer)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == newCustomer.Id);
                if(customer == null && customer.Equals(newCustomer))
                {
                    throw;
                }

                await _context.Customers.AddAsync(newCustomer);
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
        public async Task<IActionResult> AtualizarCustomer(int id)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(customerBusca => customerBusca.Id == id);

                _context.Customers.Update(customer);
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