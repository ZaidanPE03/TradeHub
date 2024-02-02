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
    public class SellOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SellOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SellOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellOrder>>> GetSellOrders()
        {
          if (_context.SellOrders == null)
          {
              return NotFound();
          }
            return await _context.SellOrders.ToListAsync();
        }

        // GET: api/SellOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellOrder>> GetSellOrder(int id)
        {
          if (_context.SellOrders == null)
          {
              return NotFound();
          }
            var sellOrder = await _context.SellOrders.FindAsync(id);

            if (sellOrder == null)
            {
                return NotFound();
            }

            return sellOrder;
        }

        // PUT: api/SellOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellOrder(int id, SellOrder sellOrder)
        {
            if (id != sellOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(sellOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellOrderExists(id))
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

        // POST: api/SellOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SellOrder>> PostSellOrder(SellOrder sellOrder)
        {
          if (_context.SellOrders == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SellOrders'  is null.");
          }
            _context.SellOrders.Add(sellOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSellOrder", new { id = sellOrder.Id }, sellOrder);
        }

        // DELETE: api/SellOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellOrder(int id)
        {
            if (_context.SellOrders == null)
            {
                return NotFound();
            }
            var sellOrder = await _context.SellOrders.FindAsync(id);
            if (sellOrder == null)
            {
                return NotFound();
            }

            _context.SellOrders.Remove(sellOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SellOrderExists(int id)
        {
            return (_context.SellOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
