using FinxGestaoPacientes.Entities;
using FinxGestaoPacientes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinxGestaoPacientes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
            if (login.Email == "admin@finx.com" && login.Senha == "123456")
            {
                var token = _authService.GerarToken(login);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
