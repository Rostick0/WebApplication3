using Microsoft.AspNetCore.Mvc;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Request;
using WebApplication3.Utils;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpGet]
        public async Task<DataResult<CategoryView>> Get([FromQuery] CategoryIndex? categoryIndex, string? title)
        {
            IQueryable<Category> dataInit = _context.Categories;

            IQueryable<CategoryView> data = dataInit.Select(x => new CategoryView(x));

            return await new DataResult<CategoryView>().AsyncInit(data, categoryIndex.Page, categoryIndex.Limit);
        }
    }
}
