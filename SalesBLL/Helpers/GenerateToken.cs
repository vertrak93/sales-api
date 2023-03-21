using SalesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SalesBLL.Helpers
{
    public class GenerateToken
    {
        public string GenerateJWTToken(User user) 
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin"), //pendiente de cambiar para cuando se implementen los roles a los usuarios
                new Claim(ClaimTypes.Role, "Sales"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new AppSettings().KeyJWT));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var secuityToken = new JwtSecurityToken(
                                claims: claims,
                                expires: DateTime.Now.AddMinutes(60),
                                signingCredentials: creds);

            string jwt = new JwtSecurityTokenHandler().WriteToken(secuityToken);

            return jwt;
        }
    }
}
