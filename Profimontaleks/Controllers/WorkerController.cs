using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using Profimontaleks.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Profimontaleks.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IServiceWorker serviceWorker;
        private readonly IServiceWorkerStatus serviceWorkerStatus;
        private readonly IServicePosition servicePosition;

        public WorkerController(IServiceWorker serviceWorker, IServiceWorkerStatus serviceWorkerStatus, IServicePosition servicePosition)
        {
            this.serviceWorker = serviceWorker;
            this.serviceWorkerStatus = serviceWorkerStatus;
            this.servicePosition = servicePosition;
        }

        [HttpGet("get-workers")]
        public IActionResult GetWorkers()
        {
            var workers = serviceWorker.GetAll();
            if (workers == null) return NotFound("There are still no workers entered or an error has occurred!");
            return Ok(workers);
        }

        [HttpGet("get-worker/{id}")]
        public IActionResult GetWorker(int id)
        {
            var worker = serviceWorker.GetById(id);
            if (worker == null) return NotFound("An error occurred while loading worker!");
            return Ok(worker);
        }

        [HttpPost("create-worker")]
        public IActionResult CreateWorker([FromBody] Worker worker)
        {
            try
            {
                serviceWorker.Add(worker);
                return CreatedAtAction("GetWorker", new { id = worker.Id }, worker);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-worker/{id}")]
        public IActionResult UpdateWorker(int id, [FromBody] Worker workerToUpdate)
        {
            if (id != workerToUpdate.Id)
            {
                return BadRequest();
            }

            try
            {
                serviceWorker.Update(workerToUpdate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
