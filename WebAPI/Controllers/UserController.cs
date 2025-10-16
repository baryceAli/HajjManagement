using Asp.Versioning;
using CoreBusiness;
using CoreBusiness.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Encodings.Web;
using WebAPI.Util;
//using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[Microsoft.AspNetCore.Mvc.ApiController]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // v1
    [ApiVersion("2.0")] // v2 (future changes)

    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        //private readonly IGenericService<User> service;

        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserController> _logger;
        private readonly AuthService authService;
        private readonly JwtSettings jwtSettings;

        //private readonly IUserStore<IdentityUser> userStore;

        public UserController(
            //IGenericService<User> service, 
            IUserService service,
                                UserManager<User> userManager,
                                RoleManager<Role> RoleManager,
                                IEmailSender emailSender,
                                IConfiguration configuration,
                                ILogger<UserController> logger,
                                AuthService authService, IOptions<JwtSettings> jwtSettings)
        {
            this.service = service;
            //this.service = service;
            this.userManager = userManager;
            roleManager = RoleManager;
            this._emailSender = emailSender;
            this.configuration = configuration;
            this._logger = logger;
            this.authService = authService;
            this.jwtSettings = jwtSettings.Value;
            //this.userStore = userStore;
            // Constructor logic can be added here if needed
        }

        [HttpGet]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get()
        {
            var users = await service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Get(int id)
        {

            var user = await userManager.FindByIdAsync(id.ToString());
            return Ok(user);
        }


        [HttpGet]
        [Route("Email/{email}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> GetUser(string email)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("User not found");

            return Ok(user);
        }

        [HttpGet]
        [Route("Roles/{email}")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> GetRoles(string email)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("User not found");

            //roleManager.GetClaimsAsync()
            var claims = await userManager.GetClaimsAsync(user);
            return Ok(user);
        }

        [HttpPost("register")]
        [MapToApiVersion("1.0")] // only available in v2
        public async Task<IActionResult> Register([FromBody] UserDto model)
        {
            try
            {

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Passport = model.Passport,
                    IssueDate = model.IssueDate,
                    ExpiryDate = model.ExpiryDate,
                    DateOfBirth = model.DateOfBirth,
                    Address = model.Address,
                    ProfilePictureUrl = model.ProfilePictureUrl,
                    CountryId = model.CountryId,
                    AdministrativeDivisionId = model.AdministrativeDivisionId,
                    PhoneNumber = model.PhoneNumber,
                    isProfileCompleted = model.isProfileCompleted,
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, GlobalData.GenerateRandomPassword(8));
                if (!result.Succeeded)
                    return BadRequest(new ApiResponseMessage { FriendlyMessage = "Failed to register new user", SytemMessage = result.Errors.FirstOrDefault().Code, IsSuccess = false, ErorrCode = "500", DetailedError = result.Errors.FirstOrDefault().Description });


                //Add Guest Role
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                var role = await roleManager.FindByNameAsync(CoreBusiness.Utils.RoleNames.Guest);

                if (existingUser != null && role != null)
                {
                    await userManager.AddToRoleAsync(existingUser, role.Name);
                }


                // 2️⃣ Build reset page link
                //var websiteUrl = configuration["HajjManagement:WebSiteURL"];  // e.g., https://localhost:7273/
                //var confirmEmailPath = configuration["HajjManagement:ConfirmEmailURL"]; // e.g., User/ResetPassword/

                // Trim trailing slashes to avoid double slashes
                //websiteUrl = websiteUrl?.TrimEnd('/');
                //confirmEmailPath = confirmEmailPath?.Trim('/');

                //var resetUrl = $"{websiteUrl}/{resetPasswordPath}/{user.Email}/{encodedToken}";

                // 1️⃣ Generate Email Confirmation Token
                var emailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedEmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));
                var emailConfirmUrl = $"{Request.Scheme}://{Request.Host}/api/v1/auth/confirm-email?userId={user.Id}&token={encodedEmailToken}";
                //emailConfirmUrl= $"{websiteUrl}/{confirmEmailPath}/{user.Id}/{encodedEmailToken}";


                var emailBody = @$"
                            <html>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                <style>
                                    body {{
                                        font-family: Arial, sans-serif;
                                        background-color: #f6f9fc;
                                        padding: 30px;
                                        color: #333;
                                    }}
                                    .container {{
                                        background: #ffffff;
                                        border-radius: 8px;
                                        box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                        max-width: 600px;
                                        margin: auto;
                                        padding: 30px;
                                    }}
                                    .header {{
                                        text-align: center;
                                        color: #28a745;
                                    }}
                                    .button {{
                                        display: inline-block;
                                        padding: 12px 24px;
                                        margin-top: 20px;
                                        background-color: #28a745;
                                        color: #fff;
                                        text-decoration: none;
                                        border-radius: 5px;
                                        font-weight: bold;
                                    }}
                                    .footer {{
                                        font-size: 12px;
                                        color: #777;
                                        text-align: center;
                                        margin-top: 30px;
                                    }}
                                </style>
                            </head>
                            <body>
                                <div class='container'>
                                    <h2 class='header'>Confirm Your Email</h2>
                                    <p>Hello <strong>{user.UserName}</strong>,</p>
                                    <p>Thank you for registering. Please confirm your email address by clicking the button below:</p>
                                    <p style='text-align:center;'>
                                        <a href='{HtmlEncoder.Default.Encode(emailConfirmUrl)}'
                                           style='display:inline-block; padding:12px 24px; margin-top:20px; background-color:#28a745; color:#ffffff !important; text-decoration:none; border-radius:5px; font-weight:bold;'>
                                           Confirm Email
                                        </a>
                                    </p>
                                    <p>If the button doesn’t work, you can also copy and paste this link into your browser:</p>
                                    <p><a href='{HtmlEncoder.Default.Encode(emailConfirmUrl)}'>{HtmlEncoder.Default.Encode(emailConfirmUrl)}</a></p>
                                    <div class='footer'>
                                        <p>© {DateTime.UtcNow.Year} Your Company Name. All rights reserved.</p>
                                    </div>
                                </div>
                            </body>
                            </html>";

                try
                {
                    await _emailSender.SendEmailAsync(user.Email, "Confirm your email", emailBody);
                }
                catch (Exception ex)
                {

                }

                // 2️⃣ Generate Phone OTP
                var otp = new Random().Next(100000, 999999).ToString();
                user.PhoneOtp = otp;
                user.PhoneOtpExpiry = DateTime.UtcNow.AddMinutes(5);
                await userManager.UpdateAsync(user);

                // TODO: Send OTP via SMS provider here (Twilio, Nexmo, etc.)

                return Ok(new ApiResponseMessage { FriendlyMessage = "User registered. Please confirm email and phone OTP.", IsSuccess = true });



            }
            catch (Exception ex)
            {

                return BadRequest(new ApiResponseMessage { FriendlyMessage = "Couldn't rgister the user", IsSuccess = false, ErorrCode = "500", DetailedError = ex.Message });
            }

        }



        [HttpPost("login")]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
        public async Task<IActionResult> Login2([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid request data.");

            try
            {
                var user = await userManager.FindByNameAsync(model.LoginCode);
                if (user == null)
                {
                    _logger.LogWarning("Login attempt failed: User not found. Username: {LoginCode}", model.LoginCode);
                    return Unauthorized("Invalid login credentials.");
                }

                if (await userManager.IsLockedOutAsync(user))
                {
                    _logger.LogWarning("Login attempt failed: Account locked. Username: {LoginCode}", model.LoginCode);
                    return Unauthorized("Account is locked.");
                }

                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    _logger.LogWarning("Login attempt failed: Email not confirmed. Username: {LoginCode}", model.LoginCode);
                    return Unauthorized("Email confirmation is required.");
                }

                var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
                if (!passwordCheck)
                {
                    await userManager.AccessFailedAsync(user); // increment access failure count
                    _logger.LogWarning("Login attempt failed: Invalid password. Username: {LoginCode}", model.LoginCode);
                    return Unauthorized("Invalid login credentials.");
                }

                // Reset access failed count
                await userManager.ResetAccessFailedCountAsync(user);

                // Generate JWT token
                var token = await authService.GenerateJwtToken(user);
                var roles = await userManager.GetRolesAsync(user);
                var userDto = UserDto.GetUserDto(user);

                _logger.LogInformation("User {LoginCode} logged in successfully.", model.LoginCode);

                return Ok(new AuthResponse
                {
                    success = true,
                    Message = "Login successful",
                    Token = token,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(jwtSettings.ExpiryMinutes),
                    User = userDto,
                    //Roles = roles.ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error during login for user {LoginCode}", model.LoginCode);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Route("ResetPasswordByAdmin")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> ResetPasswordByAdmin([FromBody] ResetPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
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
        [Route("resetPassword")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            //var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password reset successful.");
            }
            else
            {
                return BadRequest(result.Errors.Select(e => e.Description)); // Return validation errors
            }
        }

        [HttpPost("forgotPassword")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return NotFound("User not found.");

            // 1️⃣ Generate and encode token
            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(resetToken));

            // 2️⃣ Build reset page link
            var websiteUrl = configuration["HajjManagement:WebSiteURL"];  // e.g., https://localhost:7273/
            var resetPasswordPath = configuration["HajjManagement:ResetPasswordURL"]; // e.g., User/ResetPassword/

            // Trim trailing slashes to avoid double slashes
            websiteUrl = websiteUrl?.TrimEnd('/');
            resetPasswordPath = resetPasswordPath?.Trim('/');

            var resetUrl = $"{websiteUrl}/{resetPasswordPath}/{user.Email}/{encodedToken}";

            // 3️⃣ Email body
            var emailBody = @$"
                                <html>
                                <head>
                                    <meta charset='UTF-8'>
                                    <style>
                                        body {{
                                            font-family: Arial, sans-serif;
                                            background-color: #f6f9fc;
                                            padding: 30px;
                                            color: #333;
                                        }}
                                        .container {{
                                            background: #ffffff;
                                            border-radius: 8px;
                                            box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                            max-width: 600px;
                                            margin: auto;
                                            padding: 30px;
                                        }}
                                        .header {{
                                            text-align: center;
                                            color: #007bff;
                                        }}
                                        .button {{
                                            display: inline-block;
                                            padding: 12px 24px;
                                            margin-top: 20px;
                                            background-color: #007bff;
                                            color: #ffffff !important; /* fallback */
                                            text-decoration: none;
                                            border-radius: 5px;
                                            font-weight: bold;
                                        }}
                                        .footer {{
                                            font-size: 12px;
                                            color: #777;
                                            text-align: center;
                                            margin-top: 30px;
                                        }}
                                    </style>
                                </head>
                                <body>
                                    <div class='container'>
                                        <h2 class='header'>Reset Your Password</h2>
                                        <p>Hello <strong>{user.UserName}</strong>,</p>
                                        <p>Click the button below to reset your password. This link will expire soon.</p>
                                        <p style='text-align:center;'>
                                            <a href='{HtmlEncoder.Default.Encode(resetUrl)}'
                                               class='button'
                                               style='background-color:#007bff;color:#ffffff !important;text-decoration:none;border-radius:5px;padding:12px 24px;display:inline-block;font-weight:bold;'>
                                               Reset Password
                                            </a>
                                        </p>
                                        <p>If the button doesn’t work, copy and paste this link into your browser:</p>
                                        <p><a href='{HtmlEncoder.Default.Encode(resetUrl)}'>{HtmlEncoder.Default.Encode(resetUrl)}</a></p>
                                        <div class='footer'>
                                            <p>© {DateTime.UtcNow.Year} Your Company Name. All rights reserved.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";

            await _emailSender.SendEmailAsync(user.Email, "Password Reset Request", emailBody);

            return Ok("Password reset link has been sent to your email.");
        }



        [HttpPost("confirm-phone")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> ConfirmPhone([FromBody] PhoneOtpRequest model)
        {
            var user = await userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null) return NotFound();

            if (user.PhoneOtpExpiry < DateTime.UtcNow)
                return BadRequest("OTP expired");

            if (user.PhoneOtp != model.Otp)
                return BadRequest("Invalid OTP");

            user.PhoneOtp = null;
            user.PhoneOtpExpiry = null;
            user.PhoneNumberConfirmed = true;
            await userManager.UpdateAsync(user);

            return Ok("Phone confirmed successfully");
        }

        [HttpGet("confirm-email")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {


                var confirmationFailed = @"<html>
                                            <head>
                                                <meta charset='UTF-8'>
                                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                                <title>Email Confirmation</title>
                                                <!-- ✅ Include Bootstrap CSS -->
                                                <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                                            </head>

                                            <body style='font-family:Arial; background-color:#f8f9fa;'>
                                                <div class='container d-flex justify-content-center align-items-center vh-100'>
                                                    <div class='card shadow text-center' style='max-width: 500px; width:100%;'>
                                                        <div class='card-header bg-danger text-white'>
                                                            <h3>❌ Email Confirmation Failed</h3>
                                                        </div>
                                                        <div class='card-body'>
                                                            <p>Please make sure the link is correct or try again.</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </body>
                                        </html>";


                //return Content("<h2 style='color:red'>User not found</h2>", "text/html");
                return Content(confirmationFailed, "text/html");
            }
            string decodedToken;
            try
            {
                decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            }
            catch
            {
                return Content(@"<html>
                                    <head>
                                        <meta charset='UTF-8'>
                                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                        <title>Email Confirmation</title>
                                        <!-- ✅ Include Bootstrap CSS -->
                                        <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                                    </head>

                                    <body style='font-family:Arial; background-color:#f8f9fa;'>
                                        <div class='container d-flex justify-content-center align-items-center vh-100'>
                                            <div class='card shadow text-center' style='max-width: 500px; width:100%;'>
                                                <div class='card-header bg-danger text-white'>
                                                    <h3>❌ Email Confirmation Failed</h3>
                                                </div>
                                                <div class='card-body'>
                                                    <p>Please make sure the link is correct or try again.</p>
                                                </div>
                                            </div>
                                        </div>
                                    </body>
                                </html>",
                                    "text/html");
            }

            var result = await userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                var html = @$"<html>
                                <head>
                                    <meta charset='UTF-8'>
                                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                    <title>Email Confirmation</title>
                                    <!-- ✅ Include Bootstrap CSS -->
                                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                                </head>
                                <body style='font-family:Arial;text-align:center; background-color:#f8f9fa; padding:50px'>
                                    <div class='container d-flex justify-content-center align-items-center vh-100'>
                                        <div class=""card shadow text-center"" style='max-width: 500px; width:100%;'>
                                            <div class=""card-header"">
                                                <h3 class=""text-center text-success"">✅ Email Confirmed Successfully!</h3>
                                            </div>
                                            <div class=""card-body"">
                                                <p class=""text-center"">Thank you for confirming your email, <strong>{user.UserName}</strong>.</p>
                                                <p class=""text-center"">You may now close this page or log in to your account.</strong>.</p>
                                            </div>
                                            <div class=""card-footer"">
                                                <a href=""https://localhost:7273"" class=""btn btn-success"">Go to Log in page</a>
                                            </div>
                                        </div>
                                    </div>
                                </body>
                            </html>";
                return Content(html, "text/html");
            }


            var errorHtml = @"<html>
                                            <head>
                                                <meta charset='UTF-8'>
                                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                                                <title>Email Confirmation</title>
                                                <!-- ✅ Include Bootstrap CSS -->
                                                <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css' rel='stylesheet'>
                                            </head>

                                            <body style='font-family:Arial; background-color:#f8f9fa;'>
                                                <div class='container d-flex justify-content-center align-items-center vh-100'>
                                                    <div class='card shadow text-center' style='max-width: 500px; width:100%;'>
                                                        <div class='card-header bg-danger text-white'>
                                                            <h3>❌ Email Confirmation Failed</h3>
                                                        </div>
                                                        <div class='card-body'>
                                                            <p>Please make sure the link is correct or try again.</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </body>
                                        </html>";


            return Content(errorHtml, "text/html");
        }

        [HttpPost]
        [Route("logout")]
        [MapToApiVersion("1.0")] // only available in v2
        public IActionResult Logout()
        {
            // Implement logout logic here, such as invalidating the JWT token or session
            // For JWT, you might not need to do anything specific as JWTs are stateless
            return Ok(new { Message = "Logout successful" });
            //return Ok(); // Placeholder for logout logic
        }

    }
    public record PhoneOtpRequest(int UserId, string Otp);
    //public record RegisterRequest(string Email, string Password, int CountryId, string PhoneNumber);
}