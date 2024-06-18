using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Request;

namespace WebApplication3.Utils
{
    public class JWT
    {
        public static string Generate(string email, int id)
        {
            JwtOptions jwtOptions = new();
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey));

            var claims = new Claim[]{
                new(ClaimTypes.NameIdentifier, id.ToString()),
                new(ClaimTypes.Email, email),
            };

            JwtSecurityToken token = new(
                issuer: jwtOptions.Issuer,
                audience: jwtOptions.Audience,
                claims: claims,
                expires: jwtOptions.ExpirationSeconds,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static int GetUserId (string authorizationHeader)
        {
            JwtSecurityTokenHandler handler = new();
            
            return int.Parse(
                handler
                    .ReadJwtToken(authorizationHeader
                    .Substring("Bearer ".Length))
                    .Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value
           );
        }

        public static async Task<UserGet> GetUser(string authorizationHeader, ApiContext context)
        {
            JwtSecurityTokenHandler handler = new();

            var userId = handler
                .ReadJwtToken(authorizationHeader
                .Substring("Bearer ".Length))
            .Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var user = await context.Users.FirstAsync(x => x.Id == int.Parse(userId));
            Mapper mapper = new (
                new MapperConfiguration(cfg => cfg.CreateMap<User, UserGet>())
            );

            return mapper.Map<UserGet>(user);
        }

        public static async Task<User> GetuserAllInfo(string authorizationHeader, ApiContext context)
        {
            var handler = new JwtSecurityTokenHandler();

            var userId = handler
                .ReadJwtToken(authorizationHeader
                .Substring("Bearer ".Length))
            .Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return await context.Users.FirstAsync(x => x.Id == int.Parse(userId));
        }
    }
}
