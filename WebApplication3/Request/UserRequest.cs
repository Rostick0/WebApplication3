using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Request
{
    //public class UserRequest
    //{
    //}

    public class UserGet
    {
        public int Id { get; private set; }
        public string Email { get; set; } = null!;
        public float Balance { get; set; } = 0;
    }

    public class UserLogin
    {
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = null!;
        [Required, MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}
