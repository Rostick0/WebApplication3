using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Request;
using WebApplication3.Utils;

namespace WebApplication3.Filters
{
    public class TodoFilter
    {
        //IQueryable<Todo>
        public static void Set(ref IQueryable<Todo> data, TodoIndex? todoIndex, string authorizationHeader)
        {
            data = data.Where(x => x.UserId == JWT.GetUserId(authorizationHeader));

            if (todoIndex?.Title != null)
            {
                data = data.Where(x => x.Title.Contains(todoIndex.Title));
            }

            if (todoIndex?.MinDate != null)
            {
                data = data.Where(x => x.Date >= todoIndex.MinDate);
            }

            if (todoIndex?.MaxDate != null)
            {
                data = data.Where(x => x.Date <= todoIndex.MaxDate);
            }

            if (todoIndex?.CategoryId != null)
            {
                data = data.Where(x => x.CategoryId == todoIndex.CategoryId);
            }

            if (todoIndex?.TypeCategory != null)
            {
                data = data.Where(x => x.Category.Type == todoIndex.TypeCategory);
            }

            data = data.Include(x => x.Category);
        }   
    }
}
