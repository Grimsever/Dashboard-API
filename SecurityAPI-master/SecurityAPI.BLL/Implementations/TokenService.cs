using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SecurityAPI.BLL.Contracts.Responses.Identity;
using SecurityAPI.BLL.Interfaces;
using SecurityAPI.Domain.Entities;
using SecurityAPI.Domain.Options;

namespace SecurityAPI.BLL.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public AuthenticationResult GenerateAuthenticationResultForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id.ToString()),
            };

            claims.AddRange(user.Roles.Select(_ => new Claim(ClaimTypes.Role, _.Name)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            return new AuthenticationResult
            {
                Success = true,
                UserId = user.Id,
                ExpirationDate = tokenDescriptor.Expires.Value.ToLocalTime().ToString("MM/dd/yyyy HH:mm:ss"),
                Token = tokenHandler.CreateEncodedJwt(tokenDescriptor),
            };
        }
    }
}