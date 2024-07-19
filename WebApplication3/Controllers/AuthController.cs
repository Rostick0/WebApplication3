using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Request;
using WebApplication3.Result;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpPost("Login")]
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
                UserGet userGet = MapperShort.Get<User, UserGet>(user);

                return new AuthResult { User = userGet, Token = token };
            }
            catch (Exception) {
                return BadRequest(error);
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResult>> Register(User userRequest)
        {
            userRequest.Password = SecretHasher.Hash(userRequest.Password);
            await _context.Users.AddAsync(userRequest);

            await _context.SaveChangesAsync();

            var token = JWT.Generate(userRequest.Email, userRequest.Id);
            UserGet user = MapperShort.Get<User, UserGet>(userRequest);

            return new AuthResult { User = user, Token = token };
        }

        [HttpGet("Me")]
        [Authorize]
        public async Task<ActionResult<UserGet>> Me()
        {
            try
            {
                string? authorizationHeader = HttpContext.Request.Headers.Authorization;
                return await JWT.GetUserInfo(authorizationHeader, _context);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "User not found" });
            }
        }
    }
}
