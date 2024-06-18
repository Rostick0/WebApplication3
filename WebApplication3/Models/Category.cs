using System.ComponentModel.DataAnnotations;
using System.Drawing;

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
        public string Color { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Todo>? Todos { get; } = new List<Todo>();
    }
}
