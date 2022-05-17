using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Profimontaleks.Data;
using System;
using System.Threading.Tasks;

namespace Profimontaleks.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly ProfimontaleksContext context;

        public WorkerController(ProfimontaleksContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            var workers = await context.Workers.Include(x => x.Status).Include(x => x.Position).ToArrayAsync();
            if (workers == null) return NotFound("There are still no workers entered or an error has occurred!");
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorker(int id)
        {
            var worker = await context.Workers.Include(x => x.Status).Include(x => x.Position).FirstOrDefaultAsync(x => x.Id == id);
            if(worker == null) return NotFound("An error occurred while loading worker!");
            return Ok(worker);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] Worker worker)
        {
            try
            {
                worker.Status = await context.WorkerStatuses.FirstOrDefaultAsync(x => x.Id == worker.Status.Id);
                worker.Position = await context.Positions.FirstOrDefaultAsync(x => x.Id == worker.Position.Id);

                context.Add(worker);

                if (await context.SaveChangesAsync() > 0) return Ok();
                return BadRequest("An error occurred while saving a new worker!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorker(int id, [FromBody] Worker workerToUpdate)
        {
            if (id != workerToUpdate.Id)
            {
                return BadRequest();
            }

            try
            {
                var worker = await context.Workers.FirstOrDefaultAsync(x => x.Id == id);
                if (worker == null) return NotFound("An error occurred while loading worker!");

                worker.Status = await context.WorkerStatuses.FirstOrDefaultAsync(x => x.Id == workerToUpdate.Status.Id);
                worker.Position = await context.Positions.FirstOrDefaultAsync(x => x.Id == workerToUpdate.Position.Id);
                worker.NameAndSurname = workerToUpdate.NameAndSurname;
                worker.Coefficient = workerToUpdate.Coefficient;
                worker.DateOfEmployment = workerToUpdate.DateOfEmployment;

                context.Update(worker);

                if (await context.SaveChangesAsync() > 0) return Ok();

                return BadRequest("An error occurred while updating worker!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
