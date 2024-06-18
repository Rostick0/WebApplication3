using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Seeder;

namespace WebApplication3.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Todos)
                .WithOne(e => e.User)
            .IsRequired();

            modelBuilder.Entity<Category>()
               .HasMany(e => e.Todos)
               .WithOne(e => e.Category)
           .IsRequired();

           // modelBuilder.Entity<Todo>()
           //    .HasOne(e => e.Category)
           //    .WithMany(e => e.Todos)
           //.IsRequired();

            modelBuilder.Entity<Category>()
            .Property(x => x.Type)
            .HasConversion(
                r => r.ToString(),
                r => (TypeCategoryEnum)Enum.Parse(typeof(TypeCategoryEnum), r));

            DatabaseSeeder.Run(modelBuilder);
        }
    }
}
