using Asp.Versioning;
using CoreBusiness;
using CoreBusiness.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Encodings.Web;
using WebAPI.Util;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class RoleController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IEmailSender emailSender;
        private readonly AuthService authService; // optional JWT service
        private readonly ILogger<RoleController> _logger;
        private readonly IConfiguration configuration;

        public RoleController(
                                UserManager<User> userManager,
                                RoleManager<Role> roleManager,
                                IEmailSender emailSender,
                                AuthService authService,
                                ILogger<RoleController> logger,
                                IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailSender = emailSender;
            this.authService = authService;
            this._logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get()
        {
            try
            {

                var roles = await roleManager.Roles
                                .Select(r => new RoleDto
                                {
                                    Id = r.Id,
                                    Name = r.Name!,
                                    Description = r.Description
                                }).ToListAsync();

                return Ok(roles);
            }
            catch (Exception ex)
            {

                // Ideally log
                _logger.LogError(ex, "Failed to get roles");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");

            }
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get(string id)
        {
            try
            {

                Role? role = await roleManager.FindByIdAsync(id); ;
                return role != null ? Ok(role) : NotFound($"RoleId: {id}");
            }
            catch (Exception ex)
            {

                // Ideally log
                _logger.LogError(ex, "Failed to get roles");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");

            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v2
        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            try
            {
                var result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to create role: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    return BadRequest(result.Errors);
                }

                return CreatedAtAction(nameof(Get), new { id = role.Id }, role);

            }
            catch (Exception ex)
            {
                // Ideally log
                _logger.LogError(ex, "Failed to get roles");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Put(int id, [FromBody] Role updatedRole)
        {
            try
            {
                if (id != updatedRole.Id)
                    return BadRequest("Role ID mismatch.");

                var existingRole = await roleManager.FindByIdAsync(id.ToString());
                if (existingRole == null)
                    return NotFound($"Role with ID {id} not found.");

                // Update fields
                existingRole.Name = updatedRole.Name;
                existingRole.NormalizedName = updatedRole.Name.ToUpperInvariant();
                existingRole.Description = updatedRole.Description;

                var result = await roleManager.UpdateAsync(existingRole);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok(existingRole);

            }
            catch (Exception ex)
            {
                // Ideally log
                _logger.LogError(ex, "Failed to get roles");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");


                throw;
            }
        }

    }

}
