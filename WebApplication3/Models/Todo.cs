using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public class Todo: UserBelongWithDateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string? Title { get; set; } = null!;
        [MaxLength(255)]
        public string? Description { get;  set; }
        public float Sum { get; set; }
        public DateOnly Date { get; set; }
        public int CategoryId { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; } = null!;
    }

    
}
