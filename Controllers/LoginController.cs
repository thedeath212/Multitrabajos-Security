using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultitrabajosSecurity.Services;
using Org.BouncyCastle.Security;

namespace MultitrabajosSecurity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IServiceLogin _loginService;
        private readonly  IServiceUsers _serviceUser;

        public LoginController(IServiceLogin loginService, IServiceUsers serviceUser)
        {
            _loginService = loginService;
            _serviceUser = serviceUser;
        }

        [HttpPost]
        [Route("/api/auth")]
        public async Task<ActionResult> Login(DTOs.LoginRequest login)
        {
            var user = await _loginService.Login(login);
            if (user != null)
            {
                return Ok(new
                {
                    token = _loginService.generarToken(user),
                    userId = user.Id,
                    userEmail = user.Email,
                    userName = user.Name
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }

}
