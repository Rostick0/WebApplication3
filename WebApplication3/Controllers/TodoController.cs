using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Filters;
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
        public async Task<DataResult<TodoPeriodView>> GetPeriod([FromQuery] TodoIndex? todoIndex)
        {
            IQueryable<Todo> dataInit = _context.Todos;

            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            TodoFilter.Set(ref dataInit, todoIndex, authorizationHeader);
            IQueryable <TodoPeriodView> data = dataInit.GroupBy(x => x.CategoryId).Select(x => new TodoPeriodView(x.First()) { Total = x.Sum(a => a.CategoryId) });

            return await new DataResult<TodoPeriodView>().AsyncInit(data, todoIndex.Page, todoIndex.Limit);
        }

        [Authorize]
        [HttpGet]
        public async Task<DataResult<TodoView>> Get([FromQuery] TodoIndex? todoIndex)
        {
            IQueryable<Todo> dataInit = _context.Todos;

            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            TodoFilter.Set(ref dataInit, todoIndex, authorizationHeader);

            dataInit = dataInit.OrderByDescending(x => x.Id);

            IQueryable<TodoView> data = dataInit.Select(x => new TodoView(x));

            return await new DataResult<TodoView>().AsyncInit(data, todoIndex.Page, todoIndex.Limit);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> Get(int id)
        {
            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            User user = await JWT.GetuserAllInfo(authorizationHeader, _context);

            var todo = await _context.Todos.Include(x => x.Category).Where(x => x.Id == id).FirstAsync();

            if (todo == null && todo?.UserId != user.Id) return NotFound();

            return todo;
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Todo>> Create(TodoCreate todoCreate)
        {
            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            User user = await JWT.GetUser(authorizationHeader, _context);
            int userId = user.Id;

            Todo todo = MapperShort.Get<TodoCreate, Todo>(todoCreate);
            
            todo.SetUserId(
                userId
            );
            Category category = await context.Categories.FindAsync(todoCreate.CategoryId);

            user.UpdateBalanceWithCategory(todoCreate.Sum, category);

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

            string? authorizationHeader = HttpContext.Request.Headers.Authorization;
            User user = await JWT.GetuserAllInfo(authorizationHeader, _context);

            if (!TodoPolicy.Update(user, inDb))
            {
                BadRequestObjectResult badRequest = BadRequest(new { Message = "No access" });
                badRequest.StatusCode = 403;

                return badRequest;
            }

            Category category = await context.Categories.FindAsync(todoUpdate.CategoryId);

            todoUpdate.SetUserId(
                user.Id
            );
            user.RemoveCurrentOperationBalance(inDb.Sum, category);
            user.UpdateBalanceWithCategory(todoUpdate.Sum, category);

            _context.Entry(inDb).CurrentValues.SetValues(todoUpdate);

            await _context.SaveChangesAsync();

            return inDb;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> Delete(int id)
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

            Category category = await context.Categories.FindAsync(inDb.CategoryId);
            user.RemoveCurrentOperationBalance(inDb.Sum, category);
            _context.Todos.Remove(inDb);
            await _context.SaveChangesAsync();

            return "Deleted";
        }
    }
}
