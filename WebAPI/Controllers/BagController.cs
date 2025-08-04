using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagController : ControllerBase
    {
        private readonly IBagService service;

        public BagController(IBagService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bag = await service.GetAllAsync();
            return Ok(bag);
        }
        [HttpGet("{id}")]
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
