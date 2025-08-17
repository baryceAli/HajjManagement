using CoreBusiness;
using CoreBusiness.Dtos;
using Infrastructure.Interfaces;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI.Util;
//using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Microsoft.AspNetCore.Mvc.ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        //private readonly IGenericService<User> service;

        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AuthService authService;
        private readonly JwtSettings jwtSettings;

        //private readonly IUserStore<IdentityUser> userStore;

        public UserController(
            //IGenericService<User> service, 
            IUserService service,
                                UserManager<User> userManager,
                                RoleManager<Role> RoleManager,
                                AuthService authService, IOptions<JwtSettings> jwtSettings)
        {
            this.service = service;
            //this.service = service;
            this.userManager = userManager;
            roleManager = RoleManager;
            this.authService = authService;
            this.jwtSettings = jwtSettings.Value;
            //this.userStore = userStore;
            // Constructor logic can be added here if needed
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new CoreBusiness.User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.LoginCode,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Address = model.Address,
                ProfilePictureUrl = model.ProfilePictureUrl,
                CountryId = model.CountryId,
                //AdministrativeDivisionTypeId = model.AdministrativeDivisionTypeId,
                AdministrativeDivisionId = model.AdministrativeDivisionId
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Optionally, you can add user to roles or perform additional actions here
                return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
            }
            else
            {
                return BadRequest(result.Errors.Select(e => e.Description)); // Return validation errors
            }
            //return Ok(); // Placeholder for registration logic
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await userManager.FindByNameAsync(model.LoginCode);
            if (user == null)
            {
                return Unauthorized("Invalid login credentials.");
            }
            var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordCheck)
            {
                return Unauthorized("Invalid login credentials.");
            }
            // Optionally, generate a JWT token or session here
            string token = await authService.GenerateJwtToken(user); // Update to call GenerateJwtToken from authService

            var roles = await userManager.GetRolesAsync(user);

            return Ok(new AuthResponse
            {
                Message = "Login successful",
                UserId = user.Id.ToString(),
                User = user,
                Token = token,
                ExpiresAt = DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                Roles = roles.ToList()
            });
            //return Ok(new { Message = "Login successful", UserId = user.Id, Token = token });
        }
        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await userManager.FindByNameAsync(model.userName);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password reset successful.");
            }
            else
            {
                return BadRequest(result.Errors.Select(e => e.Description)); // Return validation errors
            }
        }
        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            // Implement logout logic here, such as invalidating the JWT token or session
            // For JWT, you might not need to do anything specific as JWTs are stateless
            return Ok(new { Message = "Logout successful" });
            //return Ok(); // Placeholder for logout logic
        }
    }
}