using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;
        public TypeTodoEnum Type { get; set; }
        public string IconUrl { get; set; } = null!;
        public ICollection<Todo>? Todos { get; }
    }
}
