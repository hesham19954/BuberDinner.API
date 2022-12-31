﻿using BuberDinner.Application.Services.Authentication;
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
        public IActionResult Register(RegisterRequest registerRequest)
        {
            return Ok(registerRequest);
        }
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            return Ok(loginRequest);
        }

       
    }
}
