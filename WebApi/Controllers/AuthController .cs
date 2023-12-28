using Application.DTOs.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistance.Servises;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AccountService _accountService;
        private readonly EmailService emailService
            ;
        public AuthController(TokenService tokenService, UserManager<IdentityUser> userManager, AccountService accountService, EmailService emailService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _accountService = accountService;
            this.emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var token = _tokenService.GenerateJwtToken(user);
                return Ok(new { token });
            }

            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _accountService.RegisterUserAsync(registerDto);

            if (result.Succeeded)
            {
                return Ok(new { message = "User successfully registered." });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }



        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                // ایمیل وجود ندارد یا خطای دیگر
                return BadRequest("Invalid request");
            }

            // تولید توکن بازیابی رمز عبور
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // ایجاد لینک بازیابی رمز عبور
            var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

            // ارسال ایمیل
            await emailService.SendEmailAsync(forgotPasswordDto.Email, "Reset Password", $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

            return Ok("Please check your email to reset your password.");
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return BadRequest("Invalid request");

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok("Password has been reset.");
            }

            // نمایش خطاها
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }


    }
}
