using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApplication2.Abstracts;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public enum TypeTodoEnum
    {
        [Display(Name = "Expenses")]
        Expenses,
        [Display(Name = "Income")] 
        Income
    }

    public class Todo: UserBelongWithDateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get;  set; } = null!;

        //[JsonConverter(typeof(StringEnumConverter))]
        [EnumDataType(typeof(TypeTodoEnum))]
        public TypeTodoEnum Type { get; set; }
        public float Sum { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; private set; }
    }

    
}
