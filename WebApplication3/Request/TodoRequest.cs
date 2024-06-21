using System.ComponentModel.DataAnnotations;
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
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
    }

    public class TodoCreate : UserBelongWithDateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string? Title { get; set; } = null!;
        [MaxLength(255)]
        public string? Description { get; set; }
        [Required]
        public float Sum { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }

    public class TodoUpdate : UserBelongWithDateMutationUpdated
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get; set; } = null!;
        [Required]
        public float Sum { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
