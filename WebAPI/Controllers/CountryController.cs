using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    //[Authorize(Roles = "MainSuperAdmin,MainAdmin,CompanySuperAdmin,CompanyAdmin,SuperAdmin,Admin")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService service;

        public CountryController(ICountryService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var countries =await service.GetAllAsync();
            return Ok(countries);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await service.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound($"Country with ID {id} not found.");
            }
            return Ok(country);
        }

        [Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Country country)
        {
            var created= await service.AddAsync(country);
            if (created == null)
            {
                return BadRequest("Failed to create country.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.CountryId }, created);
        }
        
        [Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            var updated = await service.UpdateAsync(country);
            if (updated == null)
            {
                return NotFound($"Country with ID {country.CountryId} not found.");
            }
            return Ok(updated);
        }
        
        [Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Country with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
