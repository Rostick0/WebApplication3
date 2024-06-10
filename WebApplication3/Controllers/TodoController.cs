using Microsoft.AspNetCore.Mvc;
using PagedList;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApiContext _context;

        public TodoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<DataResult<Todo>> Get(string? title)
        {
            IQueryable<Todo> data = _context.Todos;



            return await new DataResult<Todo>().asyncInit(data, 1, 1);
        }
    }
}
