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
    public class ErrorLogsController : ControllerBase
    {
        private readonly AdventureWorksLT2017Context _context;

        public ErrorLogsController(AdventureWorksLT2017Context context)
        {
            _context = context;
        }

        // GET: api/ErrorLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorLog>>> GetErrorLogs()
        {
          if (_context.ErrorLogs == null)
          {
              return NotFound();
          }
            return await _context.ErrorLogs.ToListAsync();
        }

        // GET: api/ErrorLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorLog>> GetErrorLog(int id)
        {
          if (_context.ErrorLogs == null)
          {
              return NotFound();
          }
            var errorLog = await _context.ErrorLogs.FindAsync(id);

            if (errorLog == null)
            {
                return NotFound();
            }

            return errorLog;
        }

        // PUT: api/ErrorLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorLog(int id, ErrorLog errorLog)
        {
            if (id != errorLog.ErrorLogID)
            {
                return BadRequest();
            }

            _context.Entry(errorLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorLogExists(id))
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

        // POST: api/ErrorLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ErrorLog>> PostErrorLog(ErrorLog errorLog)
        {
          if (_context.ErrorLogs == null)
          {
              return Problem("Entity set 'AdventureWorksLT2017Context.ErrorLogs'  is null.");
          }
            _context.ErrorLogs.Add(errorLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorLog", new { id = errorLog.ErrorLogID }, errorLog);
        }

        // DELETE: api/ErrorLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteErrorLog(int id)
        {
            if (_context.ErrorLogs == null)
            {
                return NotFound();
            }
            var errorLog = await _context.ErrorLogs.FindAsync(id);
            if (errorLog == null)
            {
                return NotFound();
            }

            _context.ErrorLogs.Remove(errorLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ErrorLogExists(int id)
        {
            return (_context.ErrorLogs?.Any(e => e.ErrorLogID == id)).GetValueOrDefault();
        }
    }
}
