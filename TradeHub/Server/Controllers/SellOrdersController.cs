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
    public class SellOrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public SellOrdersController(ApplicationDbContext context)
        public SellOrdersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/SellOrders
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<SellOrder>>> GetSellOrders()
        public async Task<IActionResult> GetSellOrders()
        {
            //if (_context.SellOrders == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.SellOrders.ToListAsync();


            var sellorders = await _unitOfWork.SellOrders.GetAll();
            return Ok(sellorders);
        }

        // GET: api/SellOrders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<SellOrder>> GetSellOrder(int id)
        public async Task<IActionResult> GetSellOrder(int id)
        {
            //if (_context.SellOrders == null)
            //{
            //    return NotFound();
            //}
            //  var sellorder = await _context.SellOrders.FindAsync(id);
            var sellorder = await _unitOfWork.SellOrders.Get(q => q.Id == id);

            if (sellorder == null)
            {
                return NotFound();
            }

            return Ok(sellorder);
        }

        // PUT: api/SellOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellOrder(int id, SellOrder sellorder)
        {
            if (id != sellorder.Id)
            {
                return BadRequest();
            }

            //_context.Entry(sellorder).State = EntityState.Modified;
            _unitOfWork.SellOrders.Update(sellorder);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!SellOrderExists(id))

                if (!await SellOrderExists(id))
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
        public async Task<ActionResult<SellOrder>> PostSellOrder(SellOrder sellorder)
        {
            //if (_context.SellOrders == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.SellOrders'  is null.");
            //}
            //_context.SellOrders.Add(sellorder);
            //await _context.SaveChangesAsync();

            await _unitOfWork.SellOrders.Insert(sellorder);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSellOrder", new { id = sellorder.Id }, sellorder);
        }

        // DELETE: api/SellOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellOrder(int id)
        {
            //if (_unitOfWork.SellOrders == null)
            //{
            //    return NotFound();
            //}
            var sellorder = await _unitOfWork.SellOrders.Get(q => q.Id == id);

            if (sellorder == null)
            {
                return NotFound();
            }

            //_context.SellOrders.Remove(sellorder);
            //await _context.SaveChangesAsync();

            await _unitOfWork.SellOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool SellOrderExists(int id)
        //{
        //    return (_context.SellOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> SellOrderExists(int id)
        {
            var sellorder = await _unitOfWork.SellOrders.Get(q => q.Id == id);

            return sellorder != null;
        }
    }
}
