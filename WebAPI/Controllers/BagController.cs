using Asp.Versioning;
using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class BagController : ControllerBase
    {
        private readonly IBagService service;

        public BagController(IBagService service)
        {
            this.service = service;
        }

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get()
        {
            var bag = await service.GetAllAsync();
            return Ok(bag);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get(int id)
        {
            var bag = await service.GetByIdAsync(id);
            if (bag == null)
            {
                return NotFound($"Bag with ID {id} not found.");
            }
            return Ok(bag);
        }
        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Create([FromBody] Bag bag)
        {
            var created = await service.AddAsync(bag);
            if (created == null)
            {
                return BadRequest("Failed to create bag.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.BagId}, created);
        }
        [HttpPut]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Update([FromBody] Bag  bag)
        {
            var updated = await service.UpdateAsync(bag);
            if (updated == null)
            {
                return NotFound($"Bag with ID {bag.BagId} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Bag with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
