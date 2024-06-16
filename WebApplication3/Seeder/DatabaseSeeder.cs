using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Seeder
{
    public class DatabaseSeeder
    {
        public static void Run(ModelBuilder modelBuilder)
        {
            CategorySeeder.Run(modelBuilder);
        }
    }
}
