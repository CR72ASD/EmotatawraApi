using DataBase.Entity.Identity;
using Methods.InterFaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Methods.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager)
        {
            var clam = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.NationalId),
                new Claim(ClaimTypes.Hash,user.Password)
            };

            var authkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:EndToken"])),
                claims: clam,
                signingCredentials: new SigningCredentials(authkey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
