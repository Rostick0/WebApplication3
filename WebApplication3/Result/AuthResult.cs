using WebApplication3.Models;

namespace WebApplication3.Result
{
    public class AuthResult
    {
        //public AuthResult(User user, string token)
        //{
        //    this.user = user;
        //    this.token = token;
        //}

        public User User { get; init; } = null!;
        public string Token { get; init; } = null!;
    }
}
