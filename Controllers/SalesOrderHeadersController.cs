﻿using System;
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
    public class SalesOrderHeadersController : ControllerBase
    {
        private readonly AdventureWorksLT2017Context _context;

        public SalesOrderHeadersController(AdventureWorksLT2017Context context)
        {
            _context = context;
        }

        // GET: api/SalesOrderHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderHeader>>> GetSalesOrderHeaders()
        {
          if (_context.SalesOrderHeaders == null)
          {
              return NotFound();
          }
            return await _context.SalesOrderHeaders.ToListAsync();
        }

        // GET: api/SalesOrderHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesOrderHeader>> GetSalesOrderHeader(int id)
        {
          if (_context.SalesOrderHeaders == null)
          {
              return NotFound();
          }
            var salesOrderHeader = await _context.SalesOrderHeaders.FindAsync(id);

            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return salesOrderHeader;
        }

        // PUT: api/SalesOrderHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesOrderHeader(int id, SalesOrderHeader salesOrderHeader)
        {
            if (id != salesOrderHeader.SalesOrderID)
            {
                return BadRequest();
            }

            _context.Entry(salesOrderHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderHeaderExists(id))
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

        // POST: api/SalesOrderHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesOrderHeader>> PostSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
          if (_context.SalesOrderHeaders == null)
          {
              return Problem("Entity set 'AdventureWorksLT2017Context.SalesOrderHeaders'  is null.");
          }
            _context.SalesOrderHeaders.Add(salesOrderHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesOrderHeader", new { id = salesOrderHeader.SalesOrderID }, salesOrderHeader);
        }

        // DELETE: api/SalesOrderHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesOrderHeader(int id)
        {
            if (_context.SalesOrderHeaders == null)
            {
                return NotFound();
            }
            var salesOrderHeader = await _context.SalesOrderHeaders.FindAsync(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            _context.SalesOrderHeaders.Remove(salesOrderHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return (_context.SalesOrderHeaders?.Any(e => e.SalesOrderID == id)).GetValueOrDefault();
        }
    }
}
