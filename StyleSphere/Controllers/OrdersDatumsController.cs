using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleSphere.Models;

namespace StyleSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDatumsController : ControllerBase
    {
        private readonly StyleSphereDbContext _context;

        public OrdersDatumsController(StyleSphereDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdersDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersDatum>>> GetOrdersData()
        {
            return await _context.OrdersData.ToListAsync();
        }

        // GET: api/OrdersDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersDatum>> GetOrdersDatum(int id)
        {
            var ordersDatum = await _context.OrdersData.FindAsync(id);

            if (ordersDatum == null)
            {
                return NotFound();
            }

            return ordersDatum;
        }

        // PUT: api/OrdersDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersDatum(int id, OrdersDatum ordersDatum)
        {
            if (id != ordersDatum.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(ordersDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersDatumExists(id))
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

        // POST: api/OrdersDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersDatum>> PostOrdersDatum(OrdersDatum ordersDatum)
        {
            _context.OrdersData.Add(ordersDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersDatum", new { id = ordersDatum.OrderId }, ordersDatum);
        }

        // DELETE: api/OrdersDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersDatum(int id)
        {
            var ordersDatum = await _context.OrdersData.FindAsync(id);
            if (ordersDatum == null)
            {
                return NotFound();
            }

            _context.OrdersData.Remove(ordersDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersDatumExists(int id)
        {
            return _context.OrdersData.Any(e => e.OrderId == id);
        }
    }
}
