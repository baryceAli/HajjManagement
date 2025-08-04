using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempRoleController : ControllerBase
    {
        private readonly IRoleService service;

        public TempRoleController(IRoleService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tempRole = await service.GetAllAsync();
            return Ok(tempRole);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tempRole = await service.GetByIdAsync(id);
            if (tempRole == null)
            {
                return NotFound($"Role with ID {id} not found.");
            }
            return Ok(tempRole);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role role)
        {
            var created = await service.AddAsync(role);
            if (created == null)
            {
                return BadRequest("Failed to create role.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Role role)
        {
            var updated = await service.UpdateAsync(role);
            if (updated == null)
            {
                return NotFound($"Role with ID {role.Id} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Role with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
