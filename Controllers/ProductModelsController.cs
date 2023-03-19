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
    public class ProductModelsController : ControllerBase
    {
        private readonly AdventureWorksLT2017Context _context;

        public ProductModelsController(AdventureWorksLT2017Context context)
        {
            _context = context;
        }

        // GET: api/ProductModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductModels()
        {
          if (_context.ProductModels == null)
          {
              return NotFound();
          }
            return await _context.ProductModels.ToListAsync();
        }

        // GET: api/ProductModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(int id)
        {
          if (_context.ProductModels == null)
          {
              return NotFound();
          }
            var productModel = await _context.ProductModels.FindAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }

        // PUT: api/ProductModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(int id, ProductModel productModel)
        {
            if (id != productModel.ProductModelID)
            {
                return BadRequest();
            }

            _context.Entry(productModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
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

        // POST: api/ProductModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProductModel(ProductModel productModel)
        {
          if (_context.ProductModels == null)
          {
              return Problem("Entity set 'AdventureWorksLT2017Context.ProductModels'  is null.");
          }
            _context.ProductModels.Add(productModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductModel", new { id = productModel.ProductModelID }, productModel);
        }

        // DELETE: api/ProductModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(int id)
        {
            if (_context.ProductModels == null)
            {
                return NotFound();
            }
            var productModel = await _context.ProductModels.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.ProductModels.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelExists(int id)
        {
            return (_context.ProductModels?.Any(e => e.ProductModelID == id)).GetValueOrDefault();
        }
    }
}
