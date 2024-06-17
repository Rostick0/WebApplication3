using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Policies;
using WebApplication3.Request;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [Authorize]
        [HttpGet("Period")]
        public async Task<DataResult<TodoPeriodView>> Get([FromQuery] TodoIndexPeriod todoIndexPeriod)
        {
            IQueryable<Todo> dataInit = _context.Todos;

            dataInit = dataInit.Where(x => x.UserId == JWT.GetUserId(HttpContext.Request.Headers.Authorization));

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

        [Authorize]
        [HttpGet]
        public async Task<DataResult<TodoView>> Get([FromQuery] TodoIndex? todoIndex)
        {
            IQueryable<Todo> dataInit = _context.Todos;

            dataInit = dataInit.Where(x => x.UserId == JWT.GetUserId(HttpContext.Request.Headers.Authorization));

            if (todoIndex?.Title != null)
            {
                dataInit = dataInit.Where(x => x.Title.Contains(todoIndex.Title));
            }

            dataInit = dataInit.OrderByDescending(x => x.Id);

            IQueryable<TodoView> data = dataInit.Select(x => new TodoView(x));

            return await new DataResult<TodoView>().AsyncInit(data, todoIndex.Page, todoIndex.Limit);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Todo>> Create(TodoCreate todoCreate)
        {
            UserGet user = await JWT.GetUser(HttpContext.Request.Headers.Authorization, _context);
            todoCreate.SetUserId(
                 user?.Id ?? 1
            );

            Todo todo = MapperShort.Get<TodoCreate, Todo>(todoCreate);

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<Todo>> Update(TodoUpdate todoUpdate, int id)
        {
            var inDb = await _context.Todos.FindAsync(id);

            if (inDb == null) return NotFound();

            User user = await JWT.GetuserAllInfo(HttpContext.Request.Headers.Authorization, _context);

            if (!TodoPolicy.Update(user, inDb))
            {
                BadRequestObjectResult badRequest = BadRequest(new { Message = "No access" });
                badRequest.StatusCode = 403;

                return badRequest;
            }

            _context.Entry(inDb).CurrentValues.SetValues(todoUpdate);

            await _context.SaveChangesAsync();

            return inDb;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> Delete(int id)
        {
            var inDb = await _context.Todos.FindAsync(id);

            if (inDb == null) return NotFound();

            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            User user = await JWT.GetuserAllInfo(authorizationHeader, _context);

            if (!TodoPolicy.Delete(user, inDb))
            {
                BadRequestObjectResult badRequest = BadRequest(new { Message = "No access" });
                badRequest.StatusCode = 403;

                return badRequest;
            }

            _context.Todos.Remove(inDb);
            await _context.SaveChangesAsync();

            return inDb;
        }
    }
}
