using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profimontaleks.Controllers
{
    [Route("api/product-type")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IServiceProductType serviceType;

        public ProductTypeController(IServiceProductType serviceType)
        {
            this.serviceType = serviceType;
        }

        [HttpGet("get-product-types")]
        public ActionResult<IEnumerable<ProductType>> GetPhases()
        {
            var types = serviceType.GetAll();
            if (types == null)
                return NotFound("There are still no product types entered or an error has occurred!");

            return Ok(types);
        }
    }
}
