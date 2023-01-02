using BuberDinner.Application.Common.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTGenerator _jwtGenerator;

        public AuthenticationService(IJWTGenerator jwtgenerator )
        {
            _jwtGenerator = jwtgenerator;
        }
        public async Task<AuthenticationResult> Login(string Email, string Password)
        {
            return new AuthenticationResult(Guid.NewGuid(),"firstname" ,"Lastname",Email,"token");
        }

        public async Task<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
        {
            string Token = _jwtGenerator.GenerateToken(Guid.NewGuid(), FirstName, LastName);
           return new AuthenticationResult(Guid.NewGuid(),FirstName,LastName,Email,Token); 
        }
    }
}
