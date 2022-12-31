using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationResult> Login(string Email, string Password)
        {
            return new AuthenticationResult(Guid.NewGuid(),"firstname" ,"Lastname",Email,"token");
        }

        public async Task<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
        {
           return new AuthenticationResult(Guid.NewGuid(),FirstName,LastName,Email,Password); 
        }
    }
}
