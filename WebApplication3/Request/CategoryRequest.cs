using System.ComponentModel.DataAnnotations;
using WebApplication2.Abstracts;
using WebApplication3.Models;

namespace WebApplication3.Request
{
    //public class CategoryRequest
    //{
    //}

    public class CategoryIndex : QueryParams
    {

    }

    public class CategoryView
    {
        public int Id { get; private set; }
        public string Title { get; set; } = null!;
        public TypeTodoEnum Type { get; set; }
        public string IconUrl { get; set; } = null!;

        public CategoryView(Category category)
        {
            Id = category.Id;
            Title = category.Title;
            Type = category.Type;
            IconUrl = category.IconUrl;
        }
    }
}
