using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeHub.Server.IRepository;
using TradeHub.Shared.Domain;

namespace TradeHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SellOrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/SellOrders
        [HttpGet]
        public async Task<IActionResult> GetSellOrders()
        {
            var SellOrders = await _unitOfWork.SellOrders.GetAll();
            return Ok(SellOrders);
        }

        // GET: api/SellOrderss/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSellOrder(int id) // Renamed method to match naming convention
        {
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);

            if (SellOrder == null)
            {
                return NotFound();
            }
            return Ok(SellOrder);
        }

        // PUT: api/SellOrderss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSellOrder(int id, SellOrder SellOrder)
        {
            if (id != SellOrder.Id)
            {
                return BadRequest();
            }

            _unitOfWork.SellOrders.Update(SellOrder);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
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

        // POST: api/SellOrderss
        [HttpPost]
        public async Task<ActionResult<SellOrder>> PostSellOrder(SellOrder SellOrder)
        {
            await _unitOfWork.SellOrders.Insert(SellOrder);
            await _unitOfWork.Save(HttpContext);

            // Ensuring the method name passed to CreatedAtAction matches the action name for getting a single SellOrder.
            return CreatedAtAction(nameof(GetSellOrder), new { id = SellOrder.Id }, SellOrder);
        }

        // DELETE: api/SellOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSellOrder(int id)
        {
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);
            if (SellOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.SellOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> SellOrderExists(int id)
        {
            var SellOrder = await _unitOfWork.SellOrders.Get(q => q.Id == id);
            return SellOrder != null;
        }
    }
}
