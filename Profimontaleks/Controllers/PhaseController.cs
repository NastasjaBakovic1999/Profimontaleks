using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/phase")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        private readonly IServicePhase servicePhase;

        public PhaseController(IServicePhase servicePhase)
        {
            this.servicePhase = servicePhase;
        }

        [HttpGet("get-phases")]
        public ActionResult<IEnumerable<Phase>> GetPhases()
        {
            var phases = servicePhase.GetAll();
            if (phases == null)
                return NotFound("There are still no phases entered or an error has occurred!");

            return Ok(phases);
        }
    }
}
