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
    public class CountryStructureController : ControllerBase
    {
        private readonly ICountryStructureService service;

        public CountryStructureController(ICountryStructureService service)
        {
            this.service = service;
        }

        // -------------------- V1 & V2 --------------------
        //    ***  Currently only one version is implemented  ***


        // -------------------- Version 1 Specific --------------------

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get()
        {
            var countryStructure = await service.GetAllAsync();
            return Ok(countryStructure);
        }
        
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get(int id)
        {
            var countryStructure = await service.GetByIdAsync(id);
            if (countryStructure == null)
            {
                return NotFound($"CountryStructure with ID {id} not found.");
            }
            return Ok(countryStructure);
        }
        
        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Create([FromBody] CountryStructure countryStructure)
        {
            var created = await service.AddAsync(countryStructure);
            if (created == null)
            {
                return BadRequest("Failed to create CountryStructure.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.CountryStructureId }, created);
        }
        
        [HttpPut]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Update([FromBody] CountryStructure countryStructure)
        {
            var updated = await service.UpdateAsync(countryStructure);
            if (updated == null)
            {
                return NotFound($"CountryStructure with ID {countryStructure.CountryStructureId} not found.");
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
                return NotFound($"CountryStructure with ID {id} not found.");
            }
            return NoContent();
        }

        // -------------------- Version 1 Specific --------------------

    }
}
