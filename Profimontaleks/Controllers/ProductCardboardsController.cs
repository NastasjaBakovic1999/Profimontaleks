using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using Profimontaleks.Services;
using Profimontaleks.Services.Interfaces;

namespace Profimontaleks.Controllers
{
    [Route("api/product-cardboards")]
    [ApiController]
    public class ProductCardboardsController : ControllerBase
    {
        private readonly IServiceProductCardboard serviceProductCardboard;
        private readonly IServiceProductCardboardPhase serviceProductCardboardPhase;

        public ProductCardboardsController(IServiceProductCardboard serviceProductCardboard, IServiceProductCardboardPhase serviceProductCardboardPhase)
        {
            this.serviceProductCardboard = serviceProductCardboard;
            this.serviceProductCardboardPhase = serviceProductCardboardPhase;
        }

        [HttpGet("get-cardboards")]
        public ActionResult<IEnumerable<ProductCardboard>> GetProductCardboards()
        {
            var productCardboards = serviceProductCardboard.GetAll();
            if (productCardboards == null)
                return NotFound("There are still no product cardboards entered or an error has occurred!");

            return Ok(productCardboards);
        }

        [HttpGet("get-cardboard/{PCCNumber}")]
        public ActionResult<ProductCardboard> GetProductCardboard(int PCCNumber)
        {
            var productCardboard = serviceProductCardboard.GetById(PCCNumber);
            if (productCardboard == null)
                return NotFound("An error occurred while loading product cardboard!");
            return Ok(productCardboard);
        }

        [HttpPut("update-cardboard/{PCCNumber}")]
        public IActionResult PutProductCardboard(int PCCNumber, [FromBody]ProductCardboard productCardboardToUpdate)
        {
            if (PCCNumber != productCardboardToUpdate.PCCNumber)
            {
                return BadRequest();
            }

            try
            {
                serviceProductCardboard.Update(productCardboardToUpdate);
                return CreatedAtAction("GetProductCardboard", new { PCCNumber = productCardboardToUpdate.PCCNumber }, productCardboardToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-cardboard")]
        public ActionResult<ProductCardboard> PostProductCardboard([FromBody] ProductCardboard productCardboard)
        {
            try
            {
                serviceProductCardboard.Add(productCardboard);
                return CreatedAtAction("GetProductCardboard", new { PCCNumber = productCardboard.PCCNumber }, productCardboard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
