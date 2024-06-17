using WebApplication3.Models;
using WebApplication3.Request;

namespace WebApplication3.Result
{
    public class AuthResult
    {
        //public AuthResult(User user, string token)
        //{
        //    this.user = user;
        //    this.token = token;
        //}

        public UserGet User { get; init; } = null!;
        public string Token { get; init; } = null!;
    }
}
