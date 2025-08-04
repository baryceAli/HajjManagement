using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempUserRoleController : ControllerBase
    {
        //private readonly ITempUserRoleService service;

        //public TempUserRoleController(ITempUserRoleService service)
        //{
        //    this.service = service;
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var tempUserRole = await service.GetAllAsync();
            //return Ok(tempUserRole);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"This is a placeholder for TempUserRole with ID {id}.");
            //var hotel = await service.GetByIdAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound($"User Role with ID {id} not found.");
            //}
            //return Ok(hotel);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User tempUserRole)
        {
            return Ok($"This is a placeholder for creating a TempUserRole with TempUserId {tempUserRole.Id} and TempRoleId {tempUserRole.Id}.");
            //var created = await service.AddAsync(tempUserRole);
            //if (created == null)
            //{
            //    return BadRequest("Failed to create user role.");
            //}
            //return CreatedAtAction(nameof(Get), new { id = created.TempUserId}, created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] int tempUserRole)
        {
            return Ok($"This is a placeholder for updating a TempUserRole with TempUserId {tempUserRole}.");
            //var updated = await service.UpdateAsync(tempUserRole);
            //if (updated == null)
            //{
            //    return NotFound($"User Role with ID {tempUserRole.TempUserId} not found.");
            //}
            //return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"This is a placeholder for deleting a TempUserRole with ID {id}.");
            //var deleted = await service.DeleteAsync(id);
            //if (!deleted)
            //{
            //    return NotFound($"User role with ID {id} not found.");
            //}
            //return NoContent();

        }
    }
}
