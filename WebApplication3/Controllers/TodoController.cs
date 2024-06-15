using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Request;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet("Period")]
        public async Task<DataResult<TodoPeriodView>> Get([FromQuery] TodoIndexPeriod todoIndexPeriod, string? title)
        {
            IQueryable<Todo> dataInit = _context.Todos;

            if (todoIndexPeriod?.DateStart != null)
            {
                dataInit = dataInit.Where(x => x.CreatedDate >= todoIndexPeriod.DateStart);
            }

            if (todoIndexPeriod?.DateEnd != null)
            {
                dataInit = dataInit.Where(x => x.CreatedDate <= todoIndexPeriod.DateEnd);
            }

            IQueryable<TodoPeriodView> data = dataInit.GroupBy(x => x.CategoryId).Select(x => new TodoPeriodView(x.First()) { Total = x.Sum(a => a.CategoryId) });

            return await new DataResult<TodoPeriodView>().AsyncInit(data, todoIndexPeriod.Page, todoIndexPeriod.Limit);
        }

        [HttpGet]
        public async Task<DataResult<Todo>> Get([FromQuery] TodoIndex? todoIndex, string? title)
        {
            IQueryable<Todo> data = _context.Todos;

            return await new DataResult<Todo>().AsyncInit(data, todoIndex.Page, todoIndex.Limit);
        }

        //[Authorize]
        [HttpPost]
        public async Task<Todo> Create(TodoCreate todoCreate)
        {
            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            //UserGet user = await JWT.GetUser(authorizationHeader, _context);
            //user.Id ??
            todoCreate.SetUserId(
                 1
            );

            Todo todo = MapperShort.Get<TodoCreate, Todo>(todoCreate);

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo;
        }
    }
}
