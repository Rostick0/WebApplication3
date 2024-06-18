namespace WebApplication3.Utils
{

    public class JwtOptions()
    {
        public string Issuer { get; } = "https://localhost:5056";
        public string Audience { get; } = "https://localhost:5056";
        public string SigningKey { get; } = "2fceb1cedfec3bc0fc94d5f85b35b2b56f3be1a056aaefd280bf66554d29456c";
        public DateTime ExpirationSeconds { get; } = DateTime.Now.AddDays(7);
    }
}
