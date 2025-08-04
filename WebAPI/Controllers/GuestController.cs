using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService service;

        public GuestController(IGuestService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var guest = await service.GetAllAsync();
            return Ok(guest);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var guest = await service.GetByIdAsync(id);
            if (guest == null)
            {
                return NotFound($"Guest with ID {id} not found.");
            }
            return Ok(guest);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Guest guest)
        {
            var created = await service.AddAsync(guest);
            if (created == null)
            {
                return BadRequest("Failed to create guest.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.GuestId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Guest guest)
        {
            var updated = await service.UpdateAsync(guest);
            if (updated == null)
            {
                return NotFound($"Guest with ID {guest.GuestId} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Guest with ID {id} not found.");
            }
            return NoContent();

        }
    }
}