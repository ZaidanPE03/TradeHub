using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeHub.Server.Data;
using TradeHub.Server.IRepository;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeOrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public TradeOrdersController(ApplicationDbContext context)
        public TradeOrdersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/TradeOrders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<TradeOrder>>> GetTradeOrders()
        public async Task<IActionResult> GetTradeOrders()
        {
            //if (_context.TradeOrders == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.TradeOrders.ToListAsync();


            var tradeorders = await _unitOfWork.TradeOrders.GetAll(includes: q => q.Include(x => x.SellOrder));
            return Ok(tradeorders);
        }

        // GET: api/TradeOrders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<TradeOrder>> GetTradeOrder(int id)
        public async Task<IActionResult> GetTradeOrder(int id)
        {
            //if (_context.TradeOrders == null)
            //{
            //    return NotFound();
            //}
            //  var tradeorder = await _context.TradeOrders.FindAsync(id);
            var tradeorder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);

            if (tradeorder == null)
            {
                return NotFound();
            }

            return Ok(tradeorder);
        }

        // PUT: api/TradeOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeOrder(int id, TradeOrder tradeorder)
        {
            if (id != tradeorder.Id)
            {
                return BadRequest();
            }

            //_context.Entry(tradeorder).State = EntityState.Modified;
            _unitOfWork.TradeOrders.Update(tradeorder);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TradeOrderExists(id))

                if (!await TradeOrderExists(id))
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
        public async Task<ActionResult<TradeOrder>> PostTradeOrder(TradeOrder tradeorder)
        {
            //if (_context.TradeOrders == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.TradeOrders'  is null.");
            //}
            //_context.TradeOrders.Add(tradeorder);
            //await _context.SaveChangesAsync();

            await _unitOfWork.TradeOrders.Insert(tradeorder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTradeOrder", new { id = tradeorder.Id }, tradeorder);
        }

        // DELETE: api/TradeOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOrder(int id)
        {
            //if (_unitOfWork.TradeOrders == null)
            //{
            //    return NotFound();
            //}
            var tradeorder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);

            if (tradeorder == null)
            {
                return NotFound();
            }

            //_context.TradeOrders.Remove(tradeorder);
            //await _context.SaveChangesAsync();

            await _unitOfWork.TradeOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool TradeOrderExists(int id)
        //{
        //    return (_context.TradeOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> TradeOrderExists(int id)
        {
            var tradeorder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);

            return tradeorder != null;
        }
    }
}
