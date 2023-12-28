using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Servises
{
    public class TokenService
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public TokenService(Microsoft.Extensions.Configuration.IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string GenerateJwtToken(IdentityUser user)
        {
            var claims = new List<Claim>
                   {
                       new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                       new Claim(ClaimTypes.NameIdentifier, user.Id)
                   };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AhmadrezaHamidiFaard09923857045"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
