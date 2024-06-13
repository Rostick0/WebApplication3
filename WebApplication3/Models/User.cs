using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public class User: DateMutation
    {
        [Key]
        public int Id { get;private set; }
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = null!;
        [Required, MaxLength(255)]
        [IgnoreDataMember]
        public string Password { get; set; } = null!;
        public ICollection<Todo> Todos { get; } = new List<Todo>();
    }

    public class UserGet
    {
        public int Id { get; private set; }
        public string Email { get; set; } = null!;
    }

    public class UserLogin
    {
        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; } = null!;
        [Required, MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}
