﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceProduct serviceProduct;

        public ProductController(IServiceProduct serviceProduct)
        {
            this.serviceProduct = serviceProduct;
        }

        [HttpGet("get-products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var phases = serviceProduct.GetAll();
            if (phases == null)
                return NotFound("There are still no products entered or an error has occurred!");

            return Ok(phases);
        }
    }
}
