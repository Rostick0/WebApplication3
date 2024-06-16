namespace WebApplication3.Utils

{
    public abstract class PageQueryParams
    {
        //public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
    }
}
