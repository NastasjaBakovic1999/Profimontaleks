using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IServicePosition servicePosition;

        public PositionController(IServicePosition servicePosition)
        {
            this.servicePosition = servicePosition;
        }

        [HttpGet("get-positions")]
        public ActionResult<IEnumerable<Position>> GetPositions()
        {
            var phases = servicePosition.GetAll();
            if (phases == null)
                return NotFound("There are still no positions entered or an error has occurred!");

            return Ok(phases);
        }
    }
}
