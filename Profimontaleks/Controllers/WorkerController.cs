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

        public WorkerController(IServiceWorker serviceWorker, IServiceWorkerStatus serviceWorkerStatus)
        {
            this.serviceWorker = serviceWorker;
            this.serviceWorkerStatus = serviceWorkerStatus;
        }

        [HttpGet]
        public IActionResult GetWorkers()
        {
            var workers = serviceWorker.GetAll();
            if (workers == null) return NotFound("There are still no workers entered or an error has occurred!");
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public IActionResult GetWorker(int id)
        {
            var worker = serviceWorker.GetById(id);
            if (worker == null) return NotFound("An error occurred while loading worker!");
            return Ok(worker);
        }

        [HttpPost]
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

        [HttpPut("{id}")]
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
