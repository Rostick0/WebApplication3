using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public async Task<DataResult<Todo>> Get([FromQuery] TodoIndex? todoIndex, string? title)
        {
            IQueryable<Todo> data = _context.Todos;

            return await new DataResult<Todo>().asyncInit(data, 1, 1);
        }

        [Authorize]
        [HttpPost]
        public async Task<Todo> Create(TodoCreate todoCreate)
        {
            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            UserGet user = await JWT.GetUser(authorizationHeader, _context);
            todoCreate.SetUserId(
                user.Id
            );

            Todo todo = MapperShort.Get<TodoCreate, Todo>(todoCreate);

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo;
        }
    }
}
