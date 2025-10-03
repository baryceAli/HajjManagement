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
    
    public class AdministrativeDivisionController : ControllerBase
    {
        private readonly IAdministrativeDivisionService service;

        public AdministrativeDivisionController(IAdministrativeDivisionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var administrativeDivision = await service.GetAllAsync();
            return Ok(administrativeDivision);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var administrativeDivision = await service.GetByIdAsync(id);
            if (administrativeDivision == null)
            {
                return NotFound($"AdministrativeDivision with ID {id} not found.");
            }
            return Ok(administrativeDivision);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdministrativeDivision administrativeDivision)
        {
            var created = await service.AddAsync(administrativeDivision);
            if (created == null)
            {
                return BadRequest("Failed to create administrativeDivision.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.AdministrativeDivisionId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdministrativeDivision administrativeDivision)
        {
            var updated = await service.UpdateAsync(administrativeDivision);
            if (updated == null)
            {
                return NotFound($"AdministrativeDivision with ID {administrativeDivision.AdministrativeDivisionId} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"AdministrativeDivision with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
