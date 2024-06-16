using WebApplication3.Models;

namespace WebApplication3.Policies
{
    public class TodoPolicy
    {
        public static bool Update(User user, Todo todo)
        {
            return user.Id == todo.UserId;
        }

        public static bool Delete(User user, Todo todo)
        {
            return user.Id == todo.UserId;
        }
    }
}
