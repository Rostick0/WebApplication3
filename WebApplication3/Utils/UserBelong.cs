using WebApplication3.Models;

namespace WebApplication3.Utils
{
    public class UserBelong
    {
        public int UserId { get; private set; }
        public virtual User? User { get; private set; }

        public void setUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class UserBelongWithDateMutation: DateMutation
    {
        public int UserId { get; private set; }
        public virtual User? User { get; private set; }

        public void setUserId(int userId)
        {
            this.UserId = userId;
        }
    }

    public class UserBelongWithDateMutationUpdated : DateMutationUpdated
    {
        public int UserId { get; private set; }
        public virtual User? User { get; private set; }

        public void setUserId(int userId)
        {
            this.UserId = userId;
        }
    }
}
