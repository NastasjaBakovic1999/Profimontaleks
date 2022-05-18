using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhaseStatusController : ControllerBase
    {
        private readonly IServicePhaseStatus servicePhaseStatus;

        public PhaseStatusController(IServicePhaseStatus servicePhaseStatus)
        {
            this.servicePhaseStatus = servicePhaseStatus;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PhaseStatus>> GetPhaseStatuses()
        {
            var phases = servicePhaseStatus.GetAll();
            if (phases == null)
                return NotFound("There are still no phase statuses entered or an error has occurred!");

            return Ok(phases);
        }
    }
}
