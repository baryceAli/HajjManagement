using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrativeDivisionTypeController : ControllerBase
    {
        private readonly IAdministrativeDivisionTypeService service;

        public AdministrativeDivisionTypeController(IAdministrativeDivisionTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var administrativeDivisionTypes = await service.GetAllAsync();
            return Ok(administrativeDivisionTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var administrativeDivisionType = await service.GetByIdAsync(id);
            if (administrativeDivisionType == null)
            {
                return NotFound($"AdministrativeDivisionType with ID {id} not found.");
            }
            return Ok(administrativeDivisionType);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdministrativeDivisionType administrativeDivisionType)
        {
            if (!ModelState.IsValid)
            {
                // Return detailed errors to client
                return BadRequest(ModelState);
            }
                var created = await service.AddAsync(administrativeDivisionType);
            if (created == null)
            {
                return BadRequest("Failed to create administrativeDivisionType.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.AdministrativeDivisionTypeId }, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdministrativeDivisionType administrativeDivisionType)
        {
            var updated = await service.UpdateAsync(administrativeDivisionType);
            if (updated == null)
            {
                return NotFound($"AdministrativeDivisionType with ID {administrativeDivisionType.AdministrativeDivisionTypeId} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"AdministrativeDivisionType with ID {id} not found.");
            }
            return NoContent();
        }

    }
}
