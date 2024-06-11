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
    public class AuthController: ControllerBase
    {
        private readonly ApiContext _context;

        public AuthController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost("auth/login")]
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

                var token = JWT.generate(user.Email, user.Id);

                return new AuthResult { User = user, Token = token };
            }
            catch (Exception) {
                return BadRequest(error);
            }
        }

        [HttpPost("auth/register")]
        public async Task<ActionResult<AuthResult>> Register(User userRequest)
        {
            userRequest.Password = SecretHasher.Hash(userRequest.Password);
            var user = await _context.Users.AddAsync(userRequest);
            //_context.Entry(comment).CurrentValues.SetValues(comment);
            await _context.SaveChangesAsync();

            var token = JWT.generate(userRequest.Email, userRequest.Id);

            return new AuthResult { User = userRequest, Token = token };
        }

        [HttpGet("auth/me")]
        [Authorize]
        public async Task<ActionResult<UserGet>> Me()
        {
            try
            {
                string? authorizationHeader = HttpContext.Request.Headers.Authorization;
                return await JWT.getUser(authorizationHeader, _context);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "User not found" });
            }
        }
    }
}
