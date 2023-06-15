using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using SalesBLL.DTO;

namespace SalesBLL.Helpers
{
    public class GenerateToken
    {
        public string GenerateJWTToken(User user, List<Role> roles) 
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in roles) 
            { 
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName)); 
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new AppSettings().KeyJWT));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var secuityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddMinutes(60),
                                signingCredentials: creds);

            string jwt = new JwtSecurityTokenHandler().WriteToken(secuityToken);

            return jwt;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetClaimsPrincipalExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new AppSettings().KeyJWT)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}
