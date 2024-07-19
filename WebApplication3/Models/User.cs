using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using WebApplication3.Data;
using WebApplication3.Migrations;
using WebApplication3.Utils;

namespace WebApplication3.Models
{
    public class User: DateMutation
    {
        [Key]
        public int Id { get;private set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public float Balance { get; private set; } = 0;
        public ICollection<Todo>? Todos { get; } = new List<Todo>();

        public void RemoveCurrentOperationBalance(float balance, Category category)
        {
            if (category?.Type == TypeCategoryEnum.Income)
            {
                this.UpdateBalance(balance * -1);
            }
            else if (category?.Type == TypeCategoryEnum.Expenses)
            {
                this.UpdateBalance(balance);
            }
        }

        public void UpdateBalanceWithCategory(float balance, Category category)
        {
            if (category?.Type == TypeCategoryEnum.Expenses)
            {
                this.UpdateBalance(balance * -1);
            }
            else if (category?.Type == TypeCategoryEnum.Income)
            {
                this.UpdateBalance(balance);
            }
        }

        public void UpdateBalance(float balance)
        {
            this.Balance += balance;
        }
    }
}
