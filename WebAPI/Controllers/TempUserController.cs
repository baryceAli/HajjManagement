using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempUserController : ControllerBase
    {
        private readonly IUserService service;

        public TempUserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tempUser = await service.GetAllAsync();
            return Ok(tempUser);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tempUser = await service.GetByIdAsync(id);
            if (tempUser == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(tempUser);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var created = await service.AddAsync(user);
            if (created == null)
            {
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            var updated = await service.UpdateAsync(user);
            if (updated == null)
            {
                return NotFound($"User with ID {user.Id} not found.");
            }
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
