namespace WebApplication2.Abstracts
{
    public abstract class QueryParams
    {
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
    }
}
