using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Infrastructure.Constants;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Authentication
{
    public class JWTGenerator : IJWTGenerator
    {
        private readonly JWTSettings _jWTSettings;

        public JWTGenerator(IOptions<JWTSettings> jWtoptions)
        {
            _jWTSettings = jWtoptions.Value;
        }
        public string GenerateToken(Guid guid, string FirstName, string LastName)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jWTSettings.Secret)),
                SecurityAlgorithms.HmacSha256
                );
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,guid.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,LastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

            };

            var securityToken = new JwtSecurityToken(
                issuer:_jWTSettings.Issuer,
                expires: DateTime.Now.AddMinutes(_jWTSettings.ExpiryMinutes),
                claims: Claims,
                signingCredentials:signingCredentials);

           return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
