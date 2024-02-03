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
    public class TradeOrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TradeOrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TradeOrders
        [HttpGet]
        public async Task<IActionResult> GetTradeOrders()
        {
            var TradeOrders = await _unitOfWork.TradeOrders.GetAll();
            return Ok(TradeOrders);
        }

        // GET: api/TradeOrderss/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTradeOrder(int id) // Renamed method to match naming convention
        {
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);

            if (TradeOrder == null)
            {
                return NotFound();
            }
            return Ok(TradeOrder);
        }

        // PUT: api/TradeOrderss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeOrder(int id, TradeOrder TradeOrder)
        {
            if (id != TradeOrder.Id)
            {
                return BadRequest();
            }

            _unitOfWork.TradeOrders.Update(TradeOrder);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
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

        // POST: api/TradeOrderss
        [HttpPost]
        public async Task<ActionResult<TradeOrder>> PostTradeOrder(TradeOrder TradeOrder)
        {
            await _unitOfWork.TradeOrders.Insert(TradeOrder);
            await _unitOfWork.Save(HttpContext);

            // Ensuring the method name passed to CreatedAtAction matches the action name for getting a single TradeOrder.
            return CreatedAtAction(nameof(GetTradeOrder), new { id = TradeOrder.Id }, TradeOrder);
        }

        // DELETE: api/TradeOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeOrder(int id)
        {
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);
            if (TradeOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.TradeOrders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TradeOrderExists(int id)
        {
            var TradeOrder = await _unitOfWork.TradeOrders.Get(q => q.Id == id);
            return TradeOrder != null;
        }
    }
}
