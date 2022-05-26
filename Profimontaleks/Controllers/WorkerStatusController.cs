using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System.Collections.Generic;

namespace Profimontaleks.Controllers
{
    [Route("api/worker-status")]
    [ApiController]
    public class WorkerStatusController : ControllerBase
    {
        private readonly IServiceWorkerStatus serviceWorkerStatus;

        public WorkerStatusController(IServiceWorkerStatus serviceWorkerStatus)
        {
            this.serviceWorkerStatus = serviceWorkerStatus;
        }

        [HttpGet("get-worker-statuses")]
        public ActionResult<IEnumerable<WorkerStatus>> GetWorkerStatuses()
        {
            var phases = serviceWorkerStatus.GetAll();
            if (phases == null)
                return NotFound("There are still no worker statuses entered or an error has occurred!");

            return Ok(phases);
        }
    }
}
