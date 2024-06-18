using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Request
{
    //public class CategoryRequest
    //{
    //}
    public class CategoryIndex: PageQueryParams
    {
        public string? Title {  get; set; }
        public TypeCategoryEnum? Type {  get; set; }
    }

    public class CategoryView(Category category)
    {
        public int Id { get; private set; } = category.Id;
        public string Title { get; set; } = category.Title;
        public TypeCategoryEnum Type { get; set; } = category.Type;
        public string? IconUrl { get; set; } = category.IconUrl;
        public string Color { get; set; } = category.Color;
    }
}
