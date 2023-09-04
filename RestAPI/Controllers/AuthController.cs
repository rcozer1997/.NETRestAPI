using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestAPI.DTO.User;
using RestAPI.Services;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {   
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (await _authService.Login(user)) 
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString); 
            }
            return BadRequest();
        }
    }
}
