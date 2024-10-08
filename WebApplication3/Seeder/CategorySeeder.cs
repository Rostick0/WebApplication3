﻿using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication3.Models;

namespace WebApplication3.Seeder
{
    public class CategorySeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Title = "Продукты", Type = TypeCategoryEnum.Expenses, Color = "#fec106" },
                new { Id = 2, Title = "Кафе", Type = TypeCategoryEnum.Expenses, Color = "#fef277" },
                new { Id = 3, Title = "Образование", Type = TypeCategoryEnum.Expenses, Color = "#1d5e1f" },
                new { Id = 4, Title = "Транспорт", Type = TypeCategoryEnum.Expenses, Color = "#e53937" },
                new { Id = 5, Title = "Дом", Type = TypeCategoryEnum.Expenses, Color = "#b49fdb" },
                new { Id = 6, Title = "Досуг", Type = TypeCategoryEnum.Expenses, Color = "#81deec" },
                new { Id = 7, Title = "Подарки", Type = TypeCategoryEnum.Expenses, Color = "#f68eb1" },
                new { Id = 8, Title = "Здоровье", Type = TypeCategoryEnum.Expenses, Color = "#f15450" },
                new { Id = 9, Title = "Одежда", Type = TypeCategoryEnum.Expenses, Color = "#01acc2" },
                new { Id = 10, Title = "Другое", Type = TypeCategoryEnum.Expenses, Color = "#5f34b0" },
                new { Id = 11, Title = "Зарплата", Type = TypeCategoryEnum.Income, Color = "#9ccd63" },
                new { Id = 12, Title = "Инвестции", Type = TypeCategoryEnum.Income, Color = "#ffec3c" },
                new { Id = 13, Title = "Бизнес", Type = TypeCategoryEnum.Income, Color = "#03897c" },
                new { Id = 14, Title = "Процент по вкладу", Type = TypeCategoryEnum.Income, Color = "#0499e7" },
                new { Id = 15, Title = "Другое", Type = TypeCategoryEnum.Income, Color = "#f06292" }
            );
        }
    }
}
