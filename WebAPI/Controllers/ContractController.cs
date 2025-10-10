using Asp.Versioning;
using CoreBusiness;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class ContractController : ControllerBase
    {
        private readonly IContractService service;

        public ContractController(IContractService service)
        {
            this.service = service;
        }

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get()
        {
            var contract = await service.GetAllAsync();
            return Ok(contract);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Get(int id)
        {
            var contract = await service.GetByIdAsync(id);
            if (contract == null)
            {
                return NotFound($"Contract with ID {id} not found.");
            }
            return Ok(contract);
        }
        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Create([FromBody] CoreBusiness.Contract contract)
        {
            var created = await service.AddAsync(contract);
            if (created == null)
            {
                return BadRequest("Failed to create contract.");
            }
            return CreatedAtAction(nameof(Get), new { id = created.ContractId }, created);
        }
        [HttpPut]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Update([FromBody] CoreBusiness.Contract contract)
        {
            var updated = await service.UpdateAsync(contract);
            if (updated == null)
            {
                return NotFound($"Contract with ID {contract.ContractId} not found.");
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
                return NotFound($"Contract with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
