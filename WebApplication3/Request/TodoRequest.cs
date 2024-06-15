using System.ComponentModel.DataAnnotations;
using WebApplication2.Abstracts;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Request
{
    //public class TodoRequest
    //{
    //}

    public class TodoPeriodView : UserBelongWithDateGetter
    {
        public int Id { get; private set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public TypeTodoEnum Type { get; set; }
        public float Sum { get; set; }
        public float Total { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; private set; }

        public TodoPeriodView(Todo todo)
        {
            this.Equals(MapperShort.Get<Todo, TodoPeriodView>(todo));
            //this = MapperShort.Get<Todo, TodoPeriodView>(todo);
        }
    }

    public class TodoIndex : QueryParams
    {

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
        public string Description { get; set; } = null!;
        public TypeTodoEnum Type { get; set; }
    }

    public class TodoUpdate : UserBelongWithDateMutationUpdated
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get; set; } = null!;
        public TypeTodoEnum Type { get; set; }
    }
}
