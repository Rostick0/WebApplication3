using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public enum TypeCategoryEnum
    {
        [Display(Name = "Expenses")]
        Expenses,
        [Display(Name = "Income")]
        Income
    }

    public class Category
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;
        public TypeCategoryEnum Type { get; set; }
        public string? IconUrl { get; set; }
        public ICollection<Todo>? Todos { get; }
    }
}
