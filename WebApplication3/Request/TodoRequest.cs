using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Request
{
    //public class TodoRequest
    //{
    //}

    public class TodoView(Todo todo) : UserIdOnlyBelongWithDateGetter(todo.UserId, todo.CreatedDate, todo.LastModifiedDate)
    {
        public int Id { get; private set; } = todo.Id;
        public string? Title { get; set; } = todo.Title;
        public string? Description { get; set; } = todo.Description;
        public float Sum { get; set; } = todo.Sum;
        public DateOnly Date { get; set; } = todo.Date;
        public int CategoryId { get; set; } = todo.CategoryId;
        public virtual Category? Category { get; set; } = todo.Category;
    }

    public class TodoPeriodView(Todo todo): TodoView(todo)
    {
        public float Total { get; set; }
    }

    public class TodoIndex : PageQueryParams
    {
        public string? Title { get; set; }
        public TypeCategoryEnum? TypeCategory { get; set; }
        public int? CategoryId { get; set; }
        public DateOnly MinDate { get; set; }
        public DateOnly MaxDate { get; set; }
    }

    public class TodoCreate : UserBelongWithDateMutation
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float Sum { get; set; }
        //[Required]
        public DateOnly? Date { get; set; } = null!;
        //[Required]
        public int CategoryId { get; set; }
    }

    

    public class TodoUpdate : UserBelongWithDateMutationUpdated
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float Sum { get; set; }
        public DateOnly? Date { get; set; } = null!;
        public int CategoryId { get; set; }
    }
}
