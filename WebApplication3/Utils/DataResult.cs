using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Utils
{
    public class DataResult<T>
    {
        public async Task<DataResult<T>> asyncInit(IQueryable<T> data, int pageNumber, int pageSize)
        {
            this.Count = await data.CountAsync();
            this.LastPage = (int)Math.Ceiling((decimal)Count / (pageNumber * pageSize));
            this.Data = await data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return this;
        }
        public List<T> Data { get; private set; } = new List<T>();
        public int? Count { get; private set; }
        public int? LastPage { get; private set; }
    }
}
