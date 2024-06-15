using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Utils
{
    public class DataResult<T>
    {
        public async Task<DataResult<T>> AsyncInit(IQueryable<T> data, int pageNumber = 1, int pageSize = 20)
        {
            this.Count = await data.CountAsync();
            this.LastPage = (int)Math.Ceiling((decimal)Count / (pageNumber * pageSize));
            this.Data = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return this;
        }
        public List<T> Data { get; private set; } = new();
        public int? Count { get; private set; }
        public int? LastPage { get; private set; }
    }
}
