using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Result;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [ApiController]
    public class AuthController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpPost("Auth/Login")]
        public async Task<ActionResult<AuthResult>> Login(UserLogin userLogin)
        {
            var error = new { Message = "The email or password is incorrect" };

            try
            {
                var user = await _context.Users.FirstAsync(x => x.Email == userLogin.Email);

                if (SecretHasher.Verify(userLogin.Password, user.Password) == false)
                {
                    return BadRequest(error);
                }

                var token = JWT.Generate(user.Email, user.Id);

                return new AuthResult { User = user, Token = token };
            }
            catch (Exception) {
                return BadRequest(error);
            }
        }

        [HttpPost("Auth/Register")]
        public async Task<ActionResult<AuthResult>> Register(User userRequest)
        {
            userRequest.Password = SecretHasher.Hash(userRequest.Password);
            await _context.Users.AddAsync(userRequest);

            await _context.SaveChangesAsync();

            var token = JWT.Generate(userRequest.Email, userRequest.Id);

            return new AuthResult { User = userRequest, Token = token };
        }

        [HttpGet("Auth/Me")]
        [Authorize]
        public async Task<ActionResult<UserGet>> Me()
        {
            try
            {
                string? authorizationHeader = HttpContext.Request.Headers.Authorization;
                return await JWT.GetUser(authorizationHeader, _context);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "User not found" });
            }
        }
    }
}
