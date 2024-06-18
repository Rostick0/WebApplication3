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
                new { Id = 1, Title = "Продукты", Type = TypeCategoryEnum.Expenses },
                new { Id = 2, Title = "Кафе", Type = TypeCategoryEnum.Expenses },
                new { Id = 3, Title = "Образование", Type = TypeCategoryEnum.Expenses },
                new { Id = 4, Title = "Транспорт", Type = TypeCategoryEnum.Expenses },
                new { Id = 5, Title = "Дом", Type = TypeCategoryEnum.Expenses },
                new { Id = 6, Title = "Досуг", Type = TypeCategoryEnum.Expenses },
                new { Id = 7, Title = "Подарки", Type = TypeCategoryEnum.Expenses },
                new { Id = 8, Title = "Здоровье", Type = TypeCategoryEnum.Expenses },
                new { Id = 9, Title = "Одежда", Type = TypeCategoryEnum.Expenses },
                new { Id = 10, Title = "Другое", Type = TypeCategoryEnum.Expenses },
                new { Id = 11, Title = "Зарплата", Type = TypeCategoryEnum.Income },
                new { Id = 12, Title = "Инвестции", Type = TypeCategoryEnum.Income },
                new { Id = 13, Title = "Бизнес", Type = TypeCategoryEnum.Income },
                new { Id = 14, Title = "Процент по вкладу", Type = TypeCategoryEnum.Income },
                new { Id = 15, Title = "Другое", Type = TypeCategoryEnum.Income }
            );
        }
    }
}
