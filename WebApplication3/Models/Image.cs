using System.ComponentModel.DataAnnotations;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public class Image: UserBelongWithDateMutation
    {
        [Key]
        public int Id { get; private set; }
        [Required, MaxLength(255)]
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public new int? UserId { get; private set; }
    }
}
