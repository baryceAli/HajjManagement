using Asp.Versioning;
using CoreBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly AuthService _authService; // optional JWT service

        public AuthController(UserManager<User> userManager, IEmailSender emailSender, AuthService authService)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _authService = authService;
        }

        [HttpPost("register")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {

            var user = new User
            {
                UserName = model.Email,
                CountryId=model.countryId,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            // 1️⃣ Generate Email Confirmation Token
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedEmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));
            var emailConfirmUrl = $"{Request.Scheme}://{Request.Host}/api/v1/auth/confirm-email?userId={user.Id}&token={encodedEmailToken}";

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
                                        <a href='{HtmlEncoder.Default.Encode(emailConfirmUrl)}' class='button'>Confirm Email</a>
                                    </p>
                                    <p>If the button doesn’t work, you can also copy and paste this link into your browser:</p>
                                    <p><a href='{HtmlEncoder.Default.Encode(emailConfirmUrl)}'>{HtmlEncoder.Default.Encode(emailConfirmUrl)}</a></p>
                                    <div class='footer'>
                                        <p>© {DateTime.UtcNow.Year} Your Company Name. All rights reserved.</p>
                                    </div>
                                </div>
                            </body>
                            </html>";
            await _emailSender.SendEmailAsync(user.Email, "Confirm your email",emailBody);

            // 2️⃣ Generate Phone OTP
            var otp = new Random().Next(100000, 999999).ToString();
            user.PhoneOtp = otp;
            user.PhoneOtpExpiry = DateTime.UtcNow.AddMinutes(5);
            await _userManager.UpdateAsync(user);

            // TODO: Send OTP via SMS provider here (Twilio, Nexmo, etc.)

            return Ok(new { Message = "User registered. Please confirm email and phone OTP." });
        }

        [HttpPost("confirm-phone")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> ConfirmPhone([FromBody] PhoneOtpRequest model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null) return NotFound();

            if (user.PhoneOtpExpiry < DateTime.UtcNow)
                return BadRequest("OTP expired");

            if (user.PhoneOtp != model.Otp)
                return BadRequest("Invalid OTP");

            user.PhoneOtp = null;
            user.PhoneOtpExpiry = null;
            user.PhoneNumberConfirmed = true;
            await _userManager.UpdateAsync(user);

            return Ok("Phone confirmed successfully");
        }

        [HttpGet("confirm-email")]
        [MapToApiVersion("1.0")] // only available in v1
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
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

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

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
    }
    public record RegisterRequest(string Email, string Password,int countryId, string PhoneNumber);
    public record PhoneOtpRequest(int UserId, string Otp);
}
