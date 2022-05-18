using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;

namespace Profimontaleks.Controllers
{
    [Route("api/product-cardboards")]
    [ApiController]
    public class ProductCardboardsController : ControllerBase
    {
        private readonly ProfimontaleksContext context;

        public ProductCardboardsController(ProfimontaleksContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCardboard>>> GetProductCardboards()
        {
            var productCardboards = await context.ProductCardboards
                                            .Include(x => x.Product)
                                            .Include(x => x.Phases)
                                            .ToListAsync();
            if (productCardboards == null)
                return NotFound("There are still no product cardboards entered or an error has occurred!");

            return Ok(productCardboards);
        }

        [HttpGet("{PCCNumber}")]
        public async Task<ActionResult<ProductCardboard>> GetProductCardboard(int PCCNumber)
        {
            var productCardboard = await context.ProductCardboards
               .Include(x => x.Product)
               .Include(x => x.Phases)
               .FirstOrDefaultAsync(x => x.PCCNumber == PCCNumber);

            if (productCardboard == null)
                return NotFound("An error occurred while loading product cardboard!");

            return Ok(productCardboard);
        }

        [HttpPut("{PCCNumber}")]
        public async Task<IActionResult> PutProductCardboard(int PCCNumber, ProductCardboard productCardboardToUpdate)
        {
            if (PCCNumber != productCardboardToUpdate.PCCNumber)
            {
                return BadRequest();
            }

            try
            {
                var productCardboard = await context.ProductCardboards.FirstOrDefaultAsync(x => x.PCCNumber == PCCNumber);
                if (productCardboard == null) return NotFound();

                productCardboard.Product = await context.Products.FirstOrDefaultAsync(x => x.Id == productCardboardToUpdate.ProductId);
                productCardboard.StartDate = productCardboardToUpdate.StartDate;
                productCardboard.EndDate = productCardboardToUpdate.EndDate;
                context.Entry(productCardboard).State = EntityState.Modified;

                context.Update(productCardboard);

                if (await context.SaveChangesAsync() > 0)
                    return CreatedAtAction("GetProductCardboard", new { PCCNumber = productCardboard.PCCNumber }, productCardboard);

                return BadRequest("An error occurred while updating product cardboard!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductCardboard>> PostProductCardboard(ProductCardboard productCardboard)
        {
            try
            {
                productCardboard.Product = await context.Products.FirstOrDefaultAsync(x => x.Id == productCardboard.ProductId);
                context.Add(productCardboard);

                if (await context.SaveChangesAsync() > 0) return CreatedAtAction("GetProductCardboard", new { PCCNumber = productCardboard.PCCNumber }, productCardboard);
                return BadRequest("An error occurred while creating new product cardboard!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
