using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Entities;
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
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJWTGenerator jwtgenerator, IUserRepository userRepository)
        {
            _jwtGenerator = jwtgenerator;
            _userRepository = userRepository;
        }
        public async Task<AuthenticationResult> Login(string Email, string Password)
        {
            User? user = await _userRepository.GetByEmail(Email);
            if (user is null)
            {
                throw new Exception("This user doesn't exist");
            }
            if (user.Password != Password)
            {
                throw new Exception("Wrong Password");
            }

            string Token =_jwtGenerator.GenerateToken(user);

            return new AuthenticationResult(Guid.NewGuid(),user.FirstName ,user.LastName,user.Email,Token);
        }

        public async Task<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
        {
            if(await _userRepository.GetByEmail(Email)is not null)
            {
                throw new Exception("User with given email already exists");
            }
            User newUser = new User() { FirstName = FirstName, LastName = LastName, Email = Email, Password = Password };
            await _userRepository.Add(newUser);
            string Token = _jwtGenerator.GenerateToken(newUser);
           return new AuthenticationResult(newUser.Id,FirstName,LastName,Email,Token); 
        }
    }
}
