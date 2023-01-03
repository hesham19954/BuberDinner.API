using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuberDinner.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
           _authenticationService = authenticationService;
        }
        // GET: api/<ValuesController>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var result =await  _authenticationService.Register(registerRequest.FirstName,registerRequest.LastName,registerRequest.Email,registerRequest.Password);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult>Login(LoginRequest loginRequest)
        {
            var result = await _authenticationService.Login(loginRequest.Email, loginRequest.Password);
            return Ok(result);
        }

       
    }
}
