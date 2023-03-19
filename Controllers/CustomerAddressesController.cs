using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestNet6.Models;

namespace ApiRestNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly AdventureWorksLT2017Context _context;

        public CustomerAddressesController(AdventureWorksLT2017Context context)
        {
            _context = context;
        }

        // GET: api/CustomerAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAddress>>> GetCustomerAddresses()
        {
          if (_context.CustomerAddresses == null)
          {
              return NotFound();
          }
            return await _context.CustomerAddresses.ToListAsync();
        }

        // GET: api/CustomerAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAddress>> GetCustomerAddress(int id)
        {
          if (_context.CustomerAddresses == null)
          {
              return NotFound();
          }
            var customerAddress = await _context.CustomerAddresses.FindAsync(id);

            if (customerAddress == null)
            {
                return NotFound();
            }

            return customerAddress;
        }

        // PUT: api/CustomerAddresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAddress(int id, CustomerAddress customerAddress)
        {
            if (id != customerAddress.CustomerID)
            {
                return BadRequest();
            }

            _context.Entry(customerAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerAddresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerAddress>> PostCustomerAddress(CustomerAddress customerAddress)
        {
          if (_context.CustomerAddresses == null)
          {
              return Problem("Entity set 'AdventureWorksLT2017Context.CustomerAddresses'  is null.");
          }
            _context.CustomerAddresses.Add(customerAddress);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerAddressExists(customerAddress.CustomerID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerAddress", new { id = customerAddress.CustomerID }, customerAddress);
        }

        // DELETE: api/CustomerAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAddress(int id)
        {
            if (_context.CustomerAddresses == null)
            {
                return NotFound();
            }
            var customerAddress = await _context.CustomerAddresses.FindAsync(id);
            if (customerAddress == null)
            {
                return NotFound();
            }

            _context.CustomerAddresses.Remove(customerAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerAddressExists(int id)
        {
            return (_context.CustomerAddresses?.Any(e => e.CustomerID == id)).GetValueOrDefault();
        }
    }
}
