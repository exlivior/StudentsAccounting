using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsAccounting.Services;
using StudentsAccounting.DTOs;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly IMailServices mailServices;
        private readonly IConfiguration configuration;

        public AuthController(IUserServices userServices, IMailServices mailServices, IConfiguration configuration)
        {
            this.userServices = userServices;
            this.mailServices = mailServices;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrerRequest user)
        {
            if (ModelState.IsValid)
            {
                var result = await userServices.RegisterUserAsync(user);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some values are not valid");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthRequest creds)
        {
            if (ModelState.IsValid)
            {
                var result = await userServices.LoginUserAsync(creds);

                if (result.IsSuccess)
                {
                    await mailServices.SendMailAsync(creds.Email, "Несанкційонований вхід!", "<h1>Було здійснено незаконний вхід в сервіс з пошти адміністратора сайту Софійки " + DateTime.Now + "</h1>");
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest("Some values are not valid");
        }

        [HttpPost("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await userServices.ConfirmEmailAsync(userId, token);

            if (result.IsSuccess)
            {
                return Redirect($"{configuration["AppUrl"]}/api/courses");
            }

            return BadRequest(result);
        }
    }
}
