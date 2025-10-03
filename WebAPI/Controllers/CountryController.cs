using Asp.Versioning;
using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    //[AllowAnonymous]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService service;

        public CountryController(ICountryService service)
        {
            this.service = service;
        }

        // -------------------- V1 & V2 --------------------
        [HttpGet]
        
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get()
        {
            var countries = await service.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get(int id)
        {
            var country = await service.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound($"Country with ID {id} not found.");
            }
            return Ok(country);
        }

        // -------------------- Only for Admins --------------------
        //[Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Create([FromBody] Country country)
        {
            var created = await service.AddAsync(country);
            if (created == null)
            {
                return BadRequest("Failed to create country.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.CountryId, version = HttpContext.GetRequestedApiVersion()?.ToString() }, created);
        }

        //[Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpPut]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Update([FromBody] Country country)
        {
            var updated = await service.UpdateAsync(country);
            if (updated == null)
            {
                return NotFound($"Country with ID {country.CountryId} not found.");
            }
            return Ok(updated);
        }

        //[Authorize(Roles = "MainSuperAdmin,MainAdmin")]
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound($"Country with ID {id} not found.");
            }
            return NoContent();
        }

        // -------------------- Version 2 Specific --------------------
        [HttpGet("summary")]
        [MapToApiVersion("2.0")] // only available in v2
        public async Task<IActionResult> GetSummary()
        {
            // Example: Return countries with only name and code
            var countries = await service.GetAllAsync();
            var summary = countries.Select(c => new { c.CountryId, c.Name, c.Code });
            return Ok(summary);
        }
    }
}
