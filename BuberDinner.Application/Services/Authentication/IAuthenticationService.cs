using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> Register(string FirstName , string LastName , string Email, string Password);
        Task<AuthenticationResult> Login(string Email,string Password);
    }
}
