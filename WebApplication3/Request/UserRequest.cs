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
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class UserRegister
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
