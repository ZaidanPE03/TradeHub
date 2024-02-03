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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var Products = await _unitOfWork.Products.GetAll();
            return Ok(Products);
        }

        // GET: api/Productss/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getproduct(int id) // Renamed method to match naming convention
        {
            var product = await _unitOfWork.Products.Get(q => q.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Productss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Products.Update(product);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await productExists(id))
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

        // POST: api/Productss
        [HttpPost]
        public async Task<ActionResult<Product>> Postproduct(Product product)
        {
            await _unitOfWork.Products.Insert(product);
            await _unitOfWork.Save(HttpContext);

            // Ensuring the method name passed to CreatedAtAction matches the action name for getting a single product.
            return CreatedAtAction(nameof(Getproduct), new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            var product = await _unitOfWork.Products.Get(q => q.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> productExists(int id)
        {
            var product = await _unitOfWork.Products.Get(q => q.Id == id);
            return product != null;
        }
    }
}
