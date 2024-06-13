using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    //public enum TypeEnum
    //{
    //    Expenses,
    //    Income
    //}

    public class Todo: DateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get;  set; } = null!;

        public int UserId { get; private set; }
        //[JsonConverter(typeof(StringEnumConverter))]
        //public TypeEnum Type { get; set; }
        public virtual User? User { get; }

        public void setUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class TodoPost
    { 

    }
}
