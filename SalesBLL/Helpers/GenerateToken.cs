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
    }
}
