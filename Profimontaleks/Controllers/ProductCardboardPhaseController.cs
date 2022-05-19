using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCardboardPhaseController : ControllerBase
    {
        private readonly IServiceProductCardboard serviceProductCardboard;
        private readonly IServiceProductCardboardPhase serviceProductCardboardPhase;

        public ProductCardboardPhaseController(IServiceProductCardboard serviceProductCardboard, IServiceProductCardboardPhase serviceProductCardboardPhase)
        {
            this.serviceProductCardboard = serviceProductCardboard;
            this.serviceProductCardboardPhase = serviceProductCardboardPhase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductCardboardPhase>> GetProductCardboardPhases(int PCCNumber)
        {
            try
            {
                var phases = serviceProductCardboardPhase.GetAllByPCCNumber(PCCNumber);
                if (phases == null)
                    return NotFound("There are still no phases entered or an error has occurred!");

                return Ok(phases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<ProductCardboardPhase> DeleteProductCardboardPhase([FromBody] ProductCardboardPhase pcp)
        {
            try
            {
                var productCardboardPhase = serviceProductCardboardPhase.GetById(pcp.PCCNumber, pcp.PhaseId);
                if (productCardboardPhase == null) return NotFound("An error occurred while loading product cardboard!");
                serviceProductCardboardPhase.Delete(pcp.PCCNumber, pcp.PhaseId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProductCardboardPhase> CreateProductCardboardPhase([FromBody]ProductCardboardPhase pcp)
        {
            try
            {
                serviceProductCardboardPhase.Add(pcp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCardboardPhase([FromBody]ProductCardboardPhase pcp)
        {
            try
            {
                serviceProductCardboardPhase.Update(pcp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
