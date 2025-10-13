using Asp.Versioning;
using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class HotelController : ControllerBase
    {
        private readonly IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get()
        {
            var hotel = await service.GetAllAsync();
            return Ok(hotel);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get(int id)
        {
            var hotel = await service.GetByIdAsync(id);
            if (hotel == null)
            {
                return NotFound($"Hotel with ID {id} not found.");
            }
            return Ok(hotel);
        }
        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Create([FromBody] Hotel hotel)
        {
            var created = await service.AddAsync(hotel);
            if (created == null)
            {
                return BadRequest("Failed to create hotel.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.HotelId}, created);
        }
        [HttpPut]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Update([FromBody] Hotel hotel)
        {
            var updated = await service.UpdateAsync(hotel);
            if (updated == null)
            {
                return NotFound($"Hotel with ID {hotel.HotelId} not found.");
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
                return NotFound($"Hotel with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
