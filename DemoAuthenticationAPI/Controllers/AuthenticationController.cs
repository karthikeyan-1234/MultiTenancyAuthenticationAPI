using DemoAuthenticationAPI.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        ITokenService tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("GetJWT")]
        public IActionResult GetJWT(string userName)
        {
            var token = tokenService.GetToken(userName);
            return Ok(token);
        }
    }
}
