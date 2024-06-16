using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Request
{
    //public class TodoRequest
    //{
    //}

    public class TodoPeriodView(Todo todo): UserBelongWithDateGetter
    {
        public int Id { get; private set; } = todo.Id;
        public string Title { get; set; } = todo.Title;
        public string? Description { get; set; } = todo.Description;

        public TypeTodoEnum Type { get; set; } = todo.Type;
        public float Sum { get; set; } = todo.Sum;
        public float Total { get; set; }
        public int CategoryId { get; set; } = todo.CategoryId;
        public virtual Category? Category { get; private set; } = todo.Category;

        //public TodoPeriodView(Todo todo)
        //{
        //    this.Equals(MapperShort.Get<Todo, TodoPeriodView>(todo));
        //    //this = MapperShort.Get<Todo, TodoPeriodView>(todo);
        //}
    }

    public class TodoIndex : PageQueryParams
    {
        public string? Title { get; set; }
    }

    public class TodoIndexPeriod : TodoIndex
    {
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }

    public class TodoCreate : UserBelongWithDateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string? Description { get; set; }
        [EnumDataType(typeof(TypeTodoEnum))]
        public TypeTodoEnum Type { get; set; }
    }

    public class TodoUpdate : UserBelongWithDateMutationUpdated
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get; set; } = null!;
        [EnumDataType(typeof(TypeTodoEnum))]
        public TypeTodoEnum Type { get; set; }
    }
}
