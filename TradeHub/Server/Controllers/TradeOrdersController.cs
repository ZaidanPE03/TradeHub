using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeHub.Server.Data;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TradeOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TradeOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeOrder>>> GetTradeOrders()
        {
          if (_context.TradeOrders == null)
          {
              return NotFound();
          }
            return await _context.TradeOrders.ToListAsync();
        }

        // GET: api/TradeOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeOrder>> GetTradeOrder(int id)
        {
          if (_context.TradeOrders == null)
          {
              return NotFound();
          }
            var tradeOrder = await _context.TradeOrders.FindAsync(id);

            if (tradeOrder == null)
            {
                return NotFound();
            }

            return tradeOrder;
        }

        // PUT: api/TradeOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeOrder(int id, TradeOrder tradeOrder)
        {
            if (id != tradeOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeOrderExists(id))
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

        // POST: api/TradeOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeOrder>> PostTradeOrder(TradeOrder tradeOrder)
        {
          if (_context.TradeOrders == null)
          {
              return Problem("Entity set 'ApplicationDbContext.TradeOrders'  is null.");
          }
            _context.TradeOrders.Add(tradeOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeOrder", new { id = tradeOrder.Id }, tradeOrder);
        }

        // DELETE: api/TradeOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOrder(int id)
        {
            if (_context.TradeOrders == null)
            {
                return NotFound();
            }
            var tradeOrder = await _context.TradeOrders.FindAsync(id);
            if (tradeOrder == null)
            {
                return NotFound();
            }

            _context.TradeOrders.Remove(tradeOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeOrderExists(int id)
        {
            return (_context.TradeOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
