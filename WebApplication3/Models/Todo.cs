using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApplication2.Abstracts;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    //public static class ValidationAttributesTodoo
    //{
    //    [Required, MaxLength(50)]
    //    public static PropertyAttributes Title { get; } = new PropertyAttributes();
    //}

    //public class ValidationUser
    //{
    //    [Required, MaxLength(50)]
    //    public string Title { get; set; } = null!;
    //}

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
        public TypeTodoEnum Type { get; set; }
        
    }

    public class TodoIndex: QueryParams
    {

    }
    
    public class TodoCreate: UserBelongWithDateMutation
    { 
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [MaxLength(255)]
        public string Description { get;  set; } = null!;
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
