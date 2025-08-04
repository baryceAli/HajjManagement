using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {

        private readonly ILogService service;

        public LogController(ILogService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var log = await service.GetAllAsync();
            return Ok(log);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var log = await service.GetByIdAsync(id);
            if (log == null)
            {
                return NotFound($"Log with ID {id} not found.");
            }
            return Ok(log);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Log log)
        {
            var created = await service.AddAsync(log);
            if (created == null)
            {
                return BadRequest("Failed to create log.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.LogId}, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Log log)
        {
            var updated = await service.UpdateAsync(log);
            if (updated == null)
            {
                return NotFound($"Log with ID {log.LogId} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Log with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
