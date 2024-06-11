using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Utils
{
    public class JWT
    {
        //private readonly ApiContext _context;

        //public JWT(ApiContext context)
        //{
        //    _context = context;
        //}

        public static string generate(string email, int id)
        {
            JwtOptions jwtOptions = new();
            
            var issuer = jwtOptions.Issuer;
            var audience = jwtOptions.Audience;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey));

            var claims = new Claim[]{
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Email, email),
                };

            
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static async Task<UserGet> getUser(string authorizationHeader, ApiContext context)
        {
            var handler = new JwtSecurityTokenHandler();

            var userId = handler
                .ReadJwtToken(authorizationHeader
                .Substring("Bearer ".Length))
            .Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var user = await context.Users.FirstAsync(x => x.Id == int.Parse(userId));
            var mapper = new Mapper(
                new MapperConfiguration(cfg => cfg.CreateMap<User, UserGet>())
            );

            return mapper.Map<UserGet>(user);
        }
}
}
