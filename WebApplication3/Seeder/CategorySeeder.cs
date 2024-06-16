using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication3.Models;

namespace WebApplication3.Seeder
{
    public class CategorySeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Title = "Продукты", Type = TypeTodoEnum.Expenses },
                new { Id = 2, Title = "Кафе", Type = TypeTodoEnum.Expenses },
                new { Id = 3, Title = "Образование", Type = TypeTodoEnum.Expenses },
                new { Id = 4, Title = "Транспорт", Type = TypeTodoEnum.Expenses },
                new { Id = 5, Title = "Дом", Type = TypeTodoEnum.Expenses },
                new { Id = 6, Title = "Досуг", Type = TypeTodoEnum.Expenses },
                new { Id = 7, Title = "Подарки", Type = TypeTodoEnum.Expenses },
                new { Id = 8, Title = "Здоровье", Type = TypeTodoEnum.Expenses },
                new { Id = 9, Title = "Одежда", Type = TypeTodoEnum.Expenses },
                new { Id = 10, Title = "Другое", Type = TypeTodoEnum.Expenses },
                new { Id = 11, Title = "Зарплата", Type = TypeTodoEnum.Income },
                new { Id = 12, Title = "Инвестции", Type = TypeTodoEnum.Income },
                new { Id = 13, Title = "Бизнес", Type = TypeTodoEnum.Income },
                new { Id = 14, Title = "Процент по вкладу", Type = TypeTodoEnum.Income },
                new { Id = 15, Title = "Другое", Type = TypeTodoEnum.Income }
            );
        }
    }
}
