using Asp.Versioning;
using CoreBusiness;
using CoreBusiness.Dtos;
using CoreBusiness.Utils;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using static CoreBusiness.Utils.Permissions;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)
    public class RoleController : ControllerBase
    {
        //private readonly UserManager<User> userManager;
        private readonly RoleManager<CoreBusiness.Role> roleManager;
        //private readonly IEmailSender emailSender;
        //private readonly AuthService authService; 
        private readonly ILogger<RoleController> _logger;
        //private readonly IConfiguration configuration;

        public RoleController(RoleManager<CoreBusiness.Role> roleManager, ILogger<RoleController> logger)
        {
            this.roleManager = roleManager;
            this._logger = logger;
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

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                // ✅ 1. Validate input
                if (id <= 0)
                {
                    _logger.LogWarning("Invalid role ID: {RoleId}", id);
                    return BadRequest("Invalid role ID.");
                }

                // ✅ 2. Get the role by ID
                var role = await roleManager.FindByIdAsync(id.ToString());
                if (role == null)
                {
                    _logger.LogWarning("Role not found: {RoleId}", id);
                    return NotFound($"Role with ID {id} not found.");
                }

                // ✅ 3. Get claims for the role
                var roleClaims = await roleManager.GetClaimsAsync(role);
                var rolePermissionSet = roleClaims
                    .Where(c => c.Type == "Permission")
                    .Select(c => c.Value)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                // ✅ 4. Get all possible permissions and update them based on the role's claims
                var allPermissions = PermissionHelper.GetAllPermissionsDetailed();

                foreach (var category in allPermissions)
                {
                    foreach (var permission in category.Permissions)
                    {
                        permission.Value = rolePermissionSet.Contains(permission.Permission);
                    }
                }

                // ✅ 5. Build response model
                var result = new RolePermissions
                {
                    Role = role,
                    Permissions = allPermissions
                };

                // ✅ 6. Return clean response
                _logger.LogInformation("Fetched role and permissions for RoleId {RoleId}", id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching role details for RoleId {RoleId}", id);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred while processing your request.");
            }
        }


        [HttpGet("{roleName}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get(string roleName)
        {
            try
            {
                // ✅ 1. Validate input
                if (string.IsNullOrWhiteSpace(roleName))
                {
                    _logger.LogWarning("Invalid role name: {roleName}", roleName);
                    return BadRequest("Invalid role RoleName.");
                }

                // ✅ 2. Get the role by ID
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    _logger.LogWarning("Role not found: {roleName}", roleName);
                    return NotFound($"Role with name {roleName} not found.");
                }

                // ✅ 3. Get claims for the role
                var roleClaims = await roleManager.GetClaimsAsync(role);
                var rolePermissionSet = roleClaims
                    .Where(c => c.Type == "Permission")
                    .Select(c => c.Value)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                // ✅ 4. Get all possible permissions and update them based on the role's claims
                var allPermissions = PermissionHelper.GetAllPermissionsDetailed();

                foreach (var category in allPermissions)
                {
                    foreach (var permission in category.Permissions)
                    {
                        permission.Value = rolePermissionSet.Contains(permission.Permission);
                    }
                }

                // ✅ 5. Build response model
                var result = new RolePermissions
                {
                    Role = role,
                    Permissions = allPermissions
                };

                // ✅ 6. Return clean response
                _logger.LogInformation("Fetched role and permissions for RoleId {roleName}", roleName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching role details for RoleName {roleName}", roleName);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred while processing your request.");
            }
        }


        [HttpPost]
        [MapToApiVersion("1.0")] // only available in v2
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolePermissions rolePermissions)
        {
            try
            {
                var result = await roleManager.CreateAsync(rolePermissions.Role);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to create role: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                    return BadRequest(result.Errors);
                }
                //Add Permissions
                foreach (var permission in rolePermissions.Permissions)
                {
                    //permission.Permissions[0].Permission
                    foreach (var per in permission.Permissions)
                    {
                        if (per.Value)
                            await roleManager.AddClaimAsync(rolePermissions.Role, new Claim("Permission", per.Permission));
                    }
                }
                return CreatedAtAction(nameof(Get), new ApiResponseMessage { IsSuccess = true, FriendlyMessage = "Added Successfully" }, rolePermissions.Role);

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
        public async Task<IActionResult> Put(int id, [FromBody] RolePermissions rolePermissions)
        {
            try
            {
                if (id != rolePermissions.Role.Id)
                {
                    _logger.LogError("Role ID mismatch.");
                    return BadRequest("Role ID mismatch.");
                }
                 CoreBusiness.Role existingRole = await roleManager.FindByIdAsync(id.ToString());
                if (existingRole == null)
                {
                    _logger.LogError($"Role with ID {id} not found.");
                    return NotFound($"Role with ID {id} not found.");
                }
                // Update fields
                existingRole.Name = rolePermissions.Role.Name;
                existingRole.NormalizedName = rolePermissions.Role.Name.ToUpperInvariant();
                existingRole.Description = rolePermissions.Role.Description;

                var result = await roleManager.UpdateAsync(existingRole);
                if (!result.Succeeded)
                {
                    _logger.LogError("Failed to update role: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));

                    return BadRequest(result.Errors);
                }
                //Get Permissions
                // ✅ 3. Get claims for the role
                var roleClaims = await roleManager.GetClaimsAsync(existingRole);
                var rolePermissionSet = roleClaims
                    .Where(c => c.Type == "Permission")
                    .Select(c => c.Value)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                // ✅ 4. Get all possible permissions and update them based on the role's claims
                var allPermissions = rolePermissions.Permissions;

                foreach (var category in allPermissions)
                {
                    foreach (var permission in category.Permissions)
                    {
                        if (permission.Value)
                        {

                            if (!rolePermissionSet.Contains(permission.Permission))
                            {
                               await roleManager.AddClaimAsync(existingRole, new Claim("Permission",permission.Permission));
                            }
                            
                        }
                        else
                        {
                            if (rolePermissionSet.Contains(permission.Permission))
                            {
                                await roleManager.RemoveClaimAsync(existingRole,new Claim("Permission", permission.Permission));
                            }
                        }
                    }
                }


                //Modify Existing Permissions and remove that with value=false

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
