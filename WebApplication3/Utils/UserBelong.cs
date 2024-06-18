using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.Utils
{
    public class UserBelong
    {
        public int UserId { get; private set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class UserIdOnlyBelongWithDateGetter(int UserId, DateTime CreatedDate, DateTime LastModifiedDate): DateGetter(CreatedDate, LastModifiedDate)
    {
        public int UserId { get; private set; } = UserId;

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class UserBelongWithDateGetter(int UserId, DateTime CreatedDate, DateTime LastModifiedDate) : UserIdOnlyBelongWithDateGetter(UserId, CreatedDate, LastModifiedDate)
    {
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }
    }

    public class UserBelongWithDateMutation: DateMutation
    {
        public int UserId { get; private set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class UserBelongWithDateMutationUpdated : DateMutationUpdated
    {
        public int UserId { get; private set; }
        [System.Text.Json.Serialization.JsonIgnore]
        [ForeignKey("UserId")]
        public virtual User? User { get; private set; }

        public void SetUserId(int userId)
        {
            this.UserId = userId;
        }
    }
}
